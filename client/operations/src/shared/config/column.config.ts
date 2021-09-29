export interface ColumnConfig {
    name: string,
    selector: (item: any) => any;
}