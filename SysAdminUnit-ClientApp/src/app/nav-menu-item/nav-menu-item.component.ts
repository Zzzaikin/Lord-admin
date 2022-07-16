import { Component, Input } from '@angular/core';
import { INavItem } from '../INavItem';

/**
 * Компонент пункта навигационного меню.
 */
@Component({
  selector: 'nav-menu-item',
  templateUrl: './nav-menu-item.component.html',
  styleUrls: ['./nav-menu-item.component.scss']
})
export class NavMenuItemComponent implements INavItem {

  /**
   * Путь к иконке.
   */
  @Input()
  public iconSrc: string = "asserts";

  /**
   * Текст пункта меню.
   */
  @Input()
  public text: string = "";

  /**
   * Название класса стилей навигационного меню.
   */
  public className: string = "nav-item";
}
