import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dictionary } from '@ngrx/entity';

/**
 * Хост Сервиса для работы с сущностями.
 */
const PROTOCOL_HOST = "http://localhost:55469";

/**
 * Провайдер к сервису сущностей для операций с данными.
 */
@Injectable({
    providedIn: 'root'
})
export class EntityService {
    /**
     * Инициализирует объект для выполнения http-запросов.
     * @param http Объект для выполнения http-запросов.
     */
    public constructor(private http: HttpClient) { }

    /**
     * Возвращает Observable с сущностями из БД.
     * @param entityName Название сущности.
     * @param count Количество селектируемых записей.
     * @param from индекс смещения в выборке.
     * @returns Объект Observable со словарём сущностей из БД.
     */
    public getEntities(entityName: string, count: number = 1000, from: number = 0): Observable<any> {
        let url = `${PROTOCOL_HOST}/${entityName}/GetEntities?from=${from}&count=${count}`;
        let entities$ = this.http.get(url);

        return entities$;
    }

    /**
     * Возвращает объект Observable с найденной в БД по указанному идентификатору сущностью.
     * @param id Идентификатор сущности.
     * @returns Объект Observable со словарём, состоящим из одной сущности, 
     * найденной в БД по указанному идентификатору.
     */
    public getEntityById(entityName: string, id: string): Observable<Dictionary<any>> {
        let url = `${PROTOCOL_HOST}/${entityName}/GetEntityById?id=${id}`;
        let entity$ = this.http.get(url);

        return entity$;
    }

    /**
     * Добавляет сущность и возвращает объект Observable с добавленной сущности.
     * @param entityName Название сущности.
     * @param entity Объект добавляемой сущности.
     * @returns Объект Observable с добавленной сущности.
     */
    public insertEntity(entityName: string, entity: any): Observable<Dictionary<any>> {
        let url = `${PROTOCOL_HOST}/${entityName}/InsertEntity`;
        let insertedEntity$ = this.http.post(url, entity);

        return insertedEntity$;
    }

    /**
     * Обновляет сущность и возвращает объект Observable с обновлённой сущности.
     * @param entityName Название сущности.
     * @param entity Объект обновляемой сущности.
     * @returns Объект Observable с обновлённой сущности.
     */
    public updateEntity(entityName: string, entity: any): Observable<any> {
        let url = `${PROTOCOL_HOST}/${entityName}/UpdateEntity`;
        let updatedEntity$ = this.http.put(url, entity);

        return updatedEntity$;
    }

    /**
     * Удаляет запись по указанному идентификатору 
     * и возвращает объект Observable с идентификатором удалённой сущности.
     * @param entityName Название сущности.
     * @param id Идентификатор сущности.
     * @returns Объект Observable со словарём, состоящим из удалённой сущности.
     */
    public deleteEntity(entityName: string, id: string): Observable<any> {
        let url = `${PROTOCOL_HOST}/${entityName}/DeleteEntity?id=${id}`;
        let deletedEntity = this.http.delete(url);

        return deletedEntity;
    }
}