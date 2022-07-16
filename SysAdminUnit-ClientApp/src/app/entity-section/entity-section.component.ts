import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IEntityState } from '../store/IEntityState';
import { Store } from '@ngrx/store';
import { Dictionary } from '@ngrx/entity';

import * as EntitySelectors from '../store/entity/entity-selectors';
import * as EntitiesActions from '../store/entity/entities-actions';
import * as Mapper from '../helpers/mapper';

/**
 * Компонент секции сущностей.
 */
@Component({
  selector: 'entity-section',
  templateUrl: './entity-section.component.html',
  styleUrls: ['./entity-section.component.scss']
})
export class EntitySectionComponent implements OnInit {
  /**
   * Массив сущностей, полученный из объекта Observable со словарём этих сущностей, приходящих из хранилища.
   */
  public entities: any[] = [];

  /**
   * Флаг состояния загрузки.
   */
  public isLoading: Boolean = false;

  /**
   * Флаг состояния успешной загрузки.
   */
  public loadedSucced: Boolean | null = null;

  /**
   * Название сущности.
   */
  private entityName: string;

  /**
   * Объект Observable со словарём сущностей из хранилища.
   */
  private entities$: Observable<Dictionary<any>> = this.entityStore.select(EntitySelectors.selectEntities);

  /**
   * Объект Observable с флагом загрузки.
   */
  private isLoading$: Observable<Boolean> = this.entityStore.select(EntitySelectors.selectIsLoading);

  /**
   * Объект Observable с статусом успешности загрузки.
   */
  private loadedSucced$: Observable<Boolean | null> = this.entityStore.select(EntitySelectors.selectIsLoadedSucceed);

  /**
   * - Инициализирует хранилище сущностей.
   * - Определяет название сущности по параметру path в location;
   * @param entityStore Хранилище сущностей.
   */
  public constructor(private entityStore: Store<IEntityState>) {
    this.entityName = window.location.pathname.replace('/', "").replace('Section', "");
  }

  /**
   * - Подписывается на все Observable;
   * - Вызывает action загрузки сущностей.
   */
  public ngOnInit(): void {
    this.entities$.subscribe(entities => {
      this.entities = Mapper.mapObjectKeysToArray(entities);
    });

    this.isLoading$.subscribe(isLoading => this.isLoading = isLoading);
    this.loadedSucced$.subscribe(loadedSucced => this.loadedSucced = loadedSucced);

    this.entityStore.dispatch(EntitiesActions.loadEntities({ entityName: this.entityName }));
  }

  /**
   * Обработчик нажатия "Попробовать ещё...".
   */
  public onRepeatClick(): void {
    this.entityStore.dispatch(EntitiesActions.loadEntities({ entityName: this.entityName }));
  }
}
