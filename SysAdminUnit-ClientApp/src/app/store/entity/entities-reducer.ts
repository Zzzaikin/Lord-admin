import { IEntityState } from "../IEntityState";
import { EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import * as EntityActions from './entities-actions';

/**
 * Адаптер для работы с сущностями.
 */
export const adapter: EntityAdapter<any> = createEntityAdapter<any>({});

/**
 * Начальное состояние хранилища.
 */
const initialState: IEntityState = adapter.getInitialState({
    isLoading: false,
    loadedSucced: null,
    error: null
});

/**
 * Редьюсеры.
 */
export const entitiesReducer = createReducer(
    initialState,

    /**
     * Редюсер на действие загрузки сущностей.
     */
    on(EntityActions.loadEntities, (state) => state.isLoading ? state : { ...state, isLoading: true, loadedSucced: null }),

    /**
     * Редьюсер на действие успешной загрузки сущностей.
     */
    on(EntityActions.loadEntitiesSucced, (state, action) => {
        let newState = adapter.addMany(action.payload, state);

        return {
            ...newState,
            isLoading: false,
            loadedSucced: true
        }
    }),

    /**
     * Редюсер на действие загрузки сущностей, завершившейся с ошибкой.
     */
    on(EntityActions.loadEntitiesFail, (state, action) => {
        return {
            ...state,
            isLoading: false,
            loadedSucced: false,
            error: action.error
        };
    })
);