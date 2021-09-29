import React, { useEffect, useState } from "react";
import DataTable from "react-data-table-component";
import { HttpService } from "../services/http.service";
import { withdrawalsColumns } from "../shared/constants/columns.constants";
import { WithdrawalModel } from "../shared/models/withdrawal.model";

export const WithdrawalsComponent: React.FC = () => {
    const initialState: WithdrawalModel[] = [];

    const [withdrawals, setWithdrawals] = useState<WithdrawalModel[]>(initialState);

    useEffect(() => {
        new HttpService<WithdrawalModel>("withdrawals").getEntities().then(data => {
            setWithdrawals(data);
            console.log(data);
        })
    }, []);

    const columns = withdrawalsColumns;

    return (
        <div>
            <DataTable
                columns={columns}
                data={withdrawals}
            />
        </div>
    )
}