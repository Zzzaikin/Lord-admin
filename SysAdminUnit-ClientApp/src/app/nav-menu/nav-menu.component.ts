import { Component, EventEmitter, Output } from '@angular/core';
import { INavItem } from '../INavItem';

/**
 * Компонент навигационного меню.
 */
@Component({
  selector: 'nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  /**
   * Событие изменения сотояния навигационного меню (скрыто/раскрыто).
   */
  @Output()
  public navStateChanged: EventEmitter<boolean> = new EventEmitter<boolean>();

  /**
   * Флаг, определяющий скрыто или не скрыто навигационное меню.
   */
  public isHided: boolean = false;

  /**
   * Текст на кнопке скрытия/раскрытия навигационного меню.
   */
  public switchButtonText: string = '<';

  /**
   * Стили кнопки переключателя. Нужны для того, чтобы задать позицию в положительную сторону 
   * при скрывании меню (движение в отрицательную сторону), чтобы переключатель не уполз вместе с навигационным меню.
   */
  public switchButtonStyle: string = "nav-switch-button btn btn-outline-info";

  /**
   * Название класса стилей навигационного меню.
   */
  public navClassName: string = "nav-wrapper";

  /**
   * Предыдущий пункт навигационного меню, по которому был осуществлён клик.
   */
  private previousClickedNavItem: INavItem = <INavItem>{};

  /**
   * Обработчик клика по пункту навигационного меню.
   * @param navItem Пункт навигационного меню, по которому осуществлён клик.
   */
  public onNavItemClick(navItem: INavItem): void {
    if (this.previousClickedNavItem) {
      this.previousClickedNavItem.className = "nav-item";
    }

    navItem.className = "nav-item clicked";
    this.previousClickedNavItem = navItem;
  }

  /**
   * Переключает состояние (скрыто/раскрыто) навигационного меню.
   */
  public switchHideMode(): void {
    if (this.isHided) {
      this.switchButtonText = '<';
      this.navClassName = "nav-wrapper";
      this.switchButtonStyle = "nav-switch-button btn btn-outline-info";
    } else {
      this.switchButtonText = '>';
      this.navClassName = "nav-wrapper nav-is-hidded";
      this.switchButtonStyle = "nav-switch-button nav-switch-button-is-hidded btn btn-outline-info";
    }

    this.navStateChanged.emit(this.isHided);
    this.isHided = !this.isHided;
  }
}
