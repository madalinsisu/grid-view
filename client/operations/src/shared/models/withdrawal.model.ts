import { OperationModel } from "./operation.model";

export interface WithdrawalModel {
    id: number;
    operationID: number;
    amount: number;
    wasApprovedByUser2FA: boolean;
    toAddress: string;
    operation: OperationModel;
}