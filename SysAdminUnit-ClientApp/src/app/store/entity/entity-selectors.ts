import { IEntityState } from './../IEntityState';
import { createSelector } from '@ngrx/store';

/**
 * Возвращает корень хранилища сущностей.
 * @param state Состояние хранилища.
 * @returns Корень хранилища сущностей.
 */
export const selectFeature = (state: any) => state.entities;

/**
 * Селектор для выборки сущностей из хранилища.
 */
export const selectEntities = createSelector(
    selectFeature,
    (state: IEntityState) => state.entities
);

/**
 * Селектор для выборки состояния загрузки.
 */
export const selectIsLoading = createSelector(
    selectFeature,
    (state: IEntityState) => state.isLoading
);

/**
 * Селектор для выборки состояния успешности загрузки.
 */
export const selectIsLoadedSucceed = createSelector(
    selectFeature,
    (state: IEntityState) => state.loadedSucced
);