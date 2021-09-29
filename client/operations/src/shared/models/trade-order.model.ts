import { OperationModel } from "./operation.model";
import { TradeOrderTypeModel } from "./trade-order-type.model";

export interface TradeOrderModel {
    id: number;
    operationid: number;
    amount: number;
    tradeOrderTypeID: number;
    tradeOrderType: TradeOrderTypeModel;
    operation: OperationModel;
}