import { SelectItemConfig } from "./config/select-item.config";
import { OperationTypeModel } from "./models/operation-type.model";

export class Helper {
    public static OperationTypeToSelectItem(operationType: OperationTypeModel): SelectItemConfig {
        const result: SelectItemConfig = {
            label: operationType.name,
            value: operationType.id.toString()
        };
        return result;
    }
}