import axios from "axios";
import { AppConfiguration } from "read-appsettings-json";
import { PaginatorConfig } from "../shared/config/paginator.config";
import { PaginatedResult } from "../shared/models/paginated-result.model";

export class HttpService<TModel> {
    public constructor(protected path: string) { }

    protected get url(): string {
        return `${AppConfiguration.Setting().serverUrl}/${this.path}`
    }

    public async getEntities(): Promise<PaginatedResult<TModel>> {
        return (await axios.get<PaginatedResult<TModel>>(this.url)).data;
    }

    public async getPaginatedEntities(pagination: PaginatorConfig): Promise<PaginatedResult<TModel>> {
        const url = `${this.url}?PageSize=${pagination.pageSize}&PageNumber=${pagination.selectedPage}`;
        return (await axios.get<PaginatedResult<TModel>>(url)).data;
    }
}