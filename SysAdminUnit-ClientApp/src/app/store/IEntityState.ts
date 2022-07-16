import { EntityState } from "@ngrx/entity";

/**
 * Интерфейс состояния хранилища сущностей.
 */
export interface IEntityState extends EntityState<any> {
    /**
     * Флаг состояния загрузки.
     */
    isLoading: Boolean,

    /**
     * Флаг состояния успешности загрузки.
     */
    loadedSucced: Boolean | null,

    /**
     * Сообщение ошибки.
     */
    error: any
}