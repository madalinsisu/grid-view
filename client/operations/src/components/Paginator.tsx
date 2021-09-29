import React, { useEffect, useState } from "react";
import Dropdown, { Option } from 'react-dropdown';
import { PaginatorConfig } from "../shared/config/paginator.config";
import { paginatorInitialState } from "../shared/constants/state.constants";
import { pageSizeDropdownStyle } from "../shared/constants/styles.constants";
import { emitCustomEvent, useCustomEventListener } from 'react-custom-events';

export const PaginatorComponent: React.FC = () => {
    const initialState: PaginatorConfig = paginatorInitialState;

    const [state, setState] = useState<PaginatorConfig>(initialState);


    const pageNumberOptions = ["1", "3", "5", "10", "20"];

    useEffect(() => {
        emitCustomEvent('paginator-changed', state);
    })

    useCustomEventListener('option-changed', (data: PaginatorConfig) => {
        setState(initialState);
    });

    useCustomEventListener('paginator-total-changed', (data: number) => {
        const pagesCount = data < state.pageSize ? 1 : Math.ceil(data / state.pageSize);
        setState({ ...state, pagesCount: pagesCount });
    });

    function onPageSizeChangged(arg: Option) {
        setState({ ...state, pageSize: Number(arg.value) });
    }

    function onPageNumberClicked(arg: number) {
        setState({ ...state, selectedPage: arg });
    }

    return (
        <div style={pageSizeDropdownStyle}>
            <div className="flex-container">
                <div className="flex-item ">
                    <Dropdown options={pageNumberOptions} value={state.pageSize.toString()} onChange={onPageSizeChangged} placeholder="Select an option" />
                </div>
                <div className="flex-item flex-container">
                    {Array.from(Array(state.pagesCount).keys()).filter(x => !!x)
                        .map(pageNumber =>
                            <div style={{ color: pageNumber === state.selectedPage ? 'blue' : 'black' }}
                                className="flex-item-button" key={pageNumber}
                                onClick={() => { onPageNumberClicked(pageNumber) }}>{pageNumber}</div>)}
                </div>
            </div>
        </div>
    )
}