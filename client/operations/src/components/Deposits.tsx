import React, { useEffect, useState } from "react";
import DataTable from "react-data-table-component";
import { HttpService } from "../services/http.service";
import { depositsColumns } from "../shared/constants/columns.constants";
import { DepositModel } from "../shared/models/deposit.model";

export const DepositsComponent: React.FC = () => {
    const initialState: DepositModel[] = [];

    const [deposits, setDeposits] = useState<DepositModel[]>(initialState);

    useEffect(() => {
        new HttpService<DepositModel>("deposits").getEntities().then(data => {
            setDeposits(data);
            console.log(data);
        })
    }, []);

    const columns = depositsColumns;

    return (
        <div>
            <DataTable
                columns={columns}
                data={deposits}
            />
        </div>
    )
}