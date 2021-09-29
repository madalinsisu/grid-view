import React, { useEffect, useState } from "react";
import { emitCustomEvent, useCustomEventListener } from "react-custom-events";
import DataTable from "react-data-table-component";
import { HttpService } from "../services/http.service";
import { PaginatorConfig } from "../shared/config/paginator.config";
import { depositsColumns } from "../shared/constants/columns.constants";
import { paginatorInitialState } from "../shared/constants/state.constants";
import { DepositModel } from "../shared/models/deposit.model";
import { PaginatorComponent } from "./Paginator";

export const DepositsComponent: React.FC = () => {
    const initialState: DepositModel[] = [];

    const [deposits, setDeposits] = useState<DepositModel[]>(initialState);

    useEffect(() => {
        fetchData(paginatorInitialState);
    }, []);

    useCustomEventListener('paginator-changed', (data: PaginatorConfig) => {
        fetchData(data);
    });

    function fetchData(paginationConfig: PaginatorConfig) {
        new HttpService<DepositModel>("deposits").getPaginatedEntities(paginationConfig).then(result => {
            setDeposits(result.items);
            emitCustomEvent('paginator-total-changed', result.totalCount);
        })
    }

    const columns = depositsColumns;

    return (
        <div>
            <DataTable
                columns={columns}
                data={deposits}
            />
            <hr></hr>
            {deposits.length > 0 && <PaginatorComponent />}
        </div>
    )
}