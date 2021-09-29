import axios from "axios";
import { AppConfiguration } from "read-appsettings-json";
import { PaginatedResult } from "../shared/models/paginated-result.model";

export class HttpService<TModel> {
    public constructor(protected path: string) { }

    protected get url(): string {
        return `${AppConfiguration.Setting().serverUrl}/${this.path}`
    }

    public async getEntities(): Promise<TModel[]> {
        return (await axios.get<PaginatedResult<TModel>>(this.url)).data.items;
    }
}