import React, { useEffect, useState } from "react";
import DataTable from "react-data-table-component";
import { HttpService } from "../services/http.service";
import { tradeOrdersColumns } from "../shared/constants/columns.constants";
import { TradeOrderModel } from "../shared/models/trade-order.model";

export const TradeOrdersComponent: React.FC = () => {
    const initialState: TradeOrderModel[] = [];

    const [tradeOrders, setTradeOrders] = useState<TradeOrderModel[]>(initialState);

    useEffect(() => {
        new HttpService<TradeOrderModel>("trade-orders").getEntities().then(data => {
            setTradeOrders(data);
            console.log(data);
        })
    }, []);

    const columns = tradeOrdersColumns;

    return (
        <div>
            <DataTable
                columns={columns}
                data={tradeOrders}
            />
        </div>
    )
}