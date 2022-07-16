import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';
import { EntityService } from '../../services/entity-service';
import * as EntityActions from './entities-actions';

/**
 * Эффекты сущностей.
 */
@Injectable()
export class EntitiesEffects {
    /**
     * Эффект загрузки сущностей.
     */
    public loadEntities$ = createEffect(() => this.actions$.pipe(
        ofType(EntityActions.loadEntities.type),
        mergeMap((action: { type: any, entityName: string }) => this.entityService.getEntities(action.entityName)
            .pipe(
                map(response => (EntityActions.loadEntitiesSucced({ payload: response }))),
                catchError((error) => of(EntityActions.loadEntitiesFail({ error: error })))
            )
        )
    ));

    /**
     * Инициализирует действия и сервис для работы с сущностями.
     * @param actions$ Действия.
     * @param entityService Сервис для работы с сущностями.
     */
    public constructor(private actions$: Actions, private entityService: EntityService) { }
}
