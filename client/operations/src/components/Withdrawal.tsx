import React, { useEffect, useState } from "react";
import { emitCustomEvent, useCustomEventListener } from "react-custom-events";
import DataTable from "react-data-table-component";
import { HttpService } from "../services/http.service";
import { PaginatorConfig } from "../shared/config/paginator.config";
import { withdrawalsColumns } from "../shared/constants/columns.constants";
import { paginatorInitialState } from "../shared/constants/state.constants";
import { WithdrawalModel } from "../shared/models/withdrawal.model";
import { PaginatorComponent } from "./Paginator";

export const WithdrawalsComponent: React.FC = () => {
    const initialState: WithdrawalModel[] = [];

    const [withdrawals, setWithdrawals] = useState<WithdrawalModel[]>(initialState);

    useEffect(() => {
        fetchData(paginatorInitialState);
    }, []);

    useCustomEventListener('paginator-changed', (data: PaginatorConfig) => {
        fetchData(data);
    });

    function fetchData(paginationConfig: PaginatorConfig) {
        new HttpService<WithdrawalModel>("withdrawals").getPaginatedEntities(paginationConfig).then(result => {
            setWithdrawals(result.items);
            emitCustomEvent('paginator-total-changed', result.totalCount);
        })
    }

    const columns = withdrawalsColumns;

    return (
        <div>
            <DataTable
                columns={columns}
                data={withdrawals}
            />
            <hr></hr>
            {withdrawals.length > 0 && <PaginatorComponent />}
        </div>
    )
}