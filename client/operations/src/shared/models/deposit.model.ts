import { OperationModel } from "./operation.model";

export interface DepositModel {
    id: number;
    operationID: number;
    amount: number;
    fromAddress: number;
    operation: OperationModel;
}