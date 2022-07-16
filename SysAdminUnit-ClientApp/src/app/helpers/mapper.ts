/**
 * Преобразует свойства объекта в массив.
 * @param obj Объект, свойства которого преобразуются в массив.
 * @returns Результирующий массив.
 */
export function mapObjectKeysToArray(obj: any): any[] {
    let array = Object.keys(obj)
        .map(function (key) {
            return obj[key];
        });

    return array;
}