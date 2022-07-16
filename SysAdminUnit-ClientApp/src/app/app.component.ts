import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SysAdminUnit-ClientApp';

  /**
   * Название класса стилей контейнера контента.
   */
  public ContentClassName: string = "content";

  /**
   * Обработчик изменения состояния навигационного меню.
   * Устанавливает стили контейнеру контента в зависимости от значения флага состояния навигационного меню.
   * @param isHided Флаг состояния навигационного меню.
   */
  public onNavStateChanged(isHided: boolean) {
    this.ContentClassName = isHided ? "content" : "content nav-is-hidded";
  }
}
