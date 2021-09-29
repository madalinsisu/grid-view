import React, { useEffect, useState } from "react";
import { emitCustomEvent, useCustomEventListener } from "react-custom-events";
import DataTable from "react-data-table-component";
import { HttpService } from "../services/http.service";
import { PaginatorConfig } from "../shared/config/paginator.config";
import { tradeOrdersColumns } from "../shared/constants/columns.constants";
import { paginatorInitialState } from "../shared/constants/state.constants";
import { TradeOrderModel } from "../shared/models/trade-order.model";
import { PaginatorComponent } from "./Paginator";

export const TradeOrdersComponent: React.FC = () => {
    const initialState: TradeOrderModel[] = [];

    const [tradeOrders, setTradeOrders] = useState<TradeOrderModel[]>(initialState);

    useEffect(() => {
        fetchData(paginatorInitialState);
    }, []);

    useCustomEventListener('paginator-changed', (data: PaginatorConfig) => {
        fetchData(data)
    });

    function fetchData(paginationConfig: PaginatorConfig) {
        new HttpService<TradeOrderModel>("trade-orders").getPaginatedEntities(paginationConfig).then(result => {
            setTradeOrders(result.items);
            emitCustomEvent('paginator-total-changed', result.totalCount);
        })
    }

    const columns = tradeOrdersColumns;

    return (
        <div>
            <DataTable
                columns={columns}
                data={tradeOrders}
            />
            <hr></hr>
            {tradeOrders.length > 0 && <PaginatorComponent />}
        </div>
    )
}