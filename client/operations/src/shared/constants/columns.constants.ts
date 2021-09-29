import { ColumnConfig } from "../config/column.config";
import { DepositModel } from "../models/deposit.model";
import { TradeOrderModel } from "../models/trade-order.model";
import { WithdrawalModel } from "../models/withdrawal.model";

export const depositsColumns: ColumnConfig[] = [
    { name: 'Amount', selector: (item: DepositModel) => item.amount },
    { name: 'From address', selector: (item: DepositModel) => item.fromAddress }
]

export const withdrawalsColumns: ColumnConfig[] = [
    { name: "Amount", selector: (item: WithdrawalModel) => item.amount },
    { name: "To Address", selector: (item: WithdrawalModel) => item.toAddress },
    { name: "2FA confirmed", selector: (item: WithdrawalModel) => item.wasApprovedByUser2FA }
]

export const tradeOrdersColumns: ColumnConfig[] = [
    { name: "Amount", selector: (item: TradeOrderModel) => item.amount },
    { name: "Trade Order Type", selector: (item: TradeOrderModel) => item.tradeOrderType?.name }
]