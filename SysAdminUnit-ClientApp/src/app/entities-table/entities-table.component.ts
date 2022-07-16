import { Component, Input, OnInit } from '@angular/core';
import * as Resourses from './entities-table-resources';

/**
 * Компонент таблицы сущностей.
 */
@Component({
  selector: 'entities-table',
  templateUrl: './entities-table.component.html',
  styleUrls: ['./entities-table.component.scss']
})
export class EntitiesTableComponent {
  /**
   * Сущности для отображения в таблице.
   */
  @Input()
  public entities: any[] = [];

  /**
   * Заголовки колонок.
   */
  public columnsCaptions: any[] = [];

  /**
   * Шаблон заголовков колонок.
   */
  private columnsCaptionsTemplate: any = {
    name: "Название",
    contact: "Контакт",
    culture: "Культура",
    active: "Активен"
  };

  /**
   * Массив названий отображаемых колонок.
   */
  public displayColumns: any[] = [
    "name",
    "contact",
    "culture",
    "active"
  ];

  public constructor() {
    this.columnsCaptions = this.getColumnsCaptions();
  }

  /**
   * Возвращает заголовки колонок по displayedColumns.
   * @returns Заголовки колонок.
   */
  public getColumnsCaptions(): string[] {
    let columnsCaptions: string[] = [];

    this.displayColumns.forEach(displayColumn => {
      let columnsCaption = this.columnsCaptionsTemplate[`${displayColumn}`];
      columnsCaptions.push(columnsCaption);
    });

    return columnsCaptions;
  }

  /**
   * Возвращает значение колонки по указанному имени колонки.
   * @param entity Сущность.
   * @param columnsName Название колонки.
   * @returns Значение колонки.
   */
  public getColumnValue(entity: any, columnsName: string): any {
    let entityValue = entity[`${columnsName}`];

    if ((typeof entityValue === 'object') && (entityValue)) {
      return entityValue.name;
    }

    if (typeof entityValue === 'boolean') {
      entityValue = entityValue ? Resourses.yes : Resourses.no
    }

    return entityValue;
  }

  public onRowClick(event: Event): void {
    let id = (<HTMLTableCellElement>event.target).parentElement?.id;//
    console.log(id);
  }
}
