import { createAction, props } from '@ngrx/store';
import { IEntityState } from "../IEntityState";

/**
 * Загрузить сущности.
 */
export const loadEntities = createAction(
    '[EntityServiceProvider] Load Entities',
    props<{ entityName: string }>()
);

/**
 * Сущности загружены успешно.
 */
export const loadEntitiesSucced = createAction(
    '[EntityServiceProvider] Load Entities Succed',
    props<{ payload: any[] }>()
);

/**
 * Загрузка сущностей завершиласб с ошибкой.
 */
export const loadEntitiesFail = createAction(
    '[EntityServiceProvider] Loaded Entities Fail',
    props<{ error: any }>()
);

export const removeEntity = createAction('[EntityServiceProvider] Remove Entity', props<IEntityState>());
export const removeEntitySucced = createAction('[EntityServiceProvider] Remove Entity Succed', props<IEntityState>());
export const removeEntityFail = createAction('[EntityServiceProvider] Remove Entity Fail', props<IEntityState>());

export const openEntity = createAction('[EntitySectionComponent] Open Entity');

export const openInsertingEntity = createAction('[EntitySectionComponent] Open Inserting Entity');
export const insertEntity = createAction('[EntityServiceProvider] Insert Entity');
export const insertEntitySucced = createAction('[EntityServiceProvider] Insert Entity Succed');
export const insertEntityFail = createAction('[EntityServiceProvider] Insert Entity Fail');

export const updateEntity = createAction('[EntityServiceProvider] Update Entity');
export const updateEntitySucced = createAction('[EntityServiceProvider] Update Entity Succed');
export const updateEntityFail = createAction('[EntityServiceProvider] Update Entity Fail');