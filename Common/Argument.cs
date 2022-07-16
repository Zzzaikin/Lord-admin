using System;

namespace SysAdminUnitsApi.Common
{
    /// <summary>
    /// Валидатор параметров.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Валидирует гуид.
        /// </summary>
        /// <param name="guid">Гуид.</param>
        /// <param name="displayParameterName">Отображаемое в ошибке имя параметра.</param>
        public static void ValidateGuid(Guid guid, string displayParameterName)
        {
            if (guid == null)
            {
                throw new ArgumentNullException($"Гуид {displayParameterName} не может быть null.");
            }

            if (guid == Guid.Empty)
            {
                throw new ArgumentNullException($"Гуид {displayParameterName} не может быть пустым.");
            }
        }

        /// <summary>
        /// Валидирует интервальные параметры.
        /// </summary>
        /// <param name="from">Индекс смещения выборки.</param>
        /// <param name="count">Количество записей.</param>
        /// <param name="maxRecordsCount">Максимальное количество записей.</param>
        public static void ValidateIntervalParams(int from, int count, int maxRecordsCount)
        {
            if (from < 0)
            {
                throw new Exception($"Параметер {nameof(from)} не может быть меньше, чем ноль.");
            }

            if (count <= 0)
            {
                throw new Exception($"Параметер {nameof(count)} не может быть меньше, чем ноль или равен ему.");
            }

            if (count > maxRecordsCount)
            {
                throw new ArgumentException($"Количество записей в выборке не может быть больше {maxRecordsCount}");
            }
        }

        /// <summary>
        /// Проверяет на null.
        /// </summary>
        /// <param name="validatedObject">Валидируемый объект</param>
        /// <param name="displayObjectName">Отображаемое имя параметра, который проходит проверку.</param>
        public static void IsNull(object validatedObject, string displayObjectName)
        {
            if (validatedObject == null)
            {
                throw new ArgumentException($"Параметр {displayObjectName} не может быть null");
            }
        }

        /// <summary>
        /// Валидирует строку на null и пустоту.
        /// </summary>
        /// <param name="validatedString">Валидируемая строка.</param>
        /// <param name="displayName">Отображаемое имя параметра, который проходит проверку.</param>
        public static void ValidateString(string validatedString, string displayName)
        {
            if (string.IsNullOrEmpty(validatedString))
            {
                throw new ArgumentException($"{displayName} не может быть null или пустой");
            }
        }

        /// <summary>
        /// Проверяет аргумент, значение которого должно быть больше нуля.
        /// </summary>
        /// <param name="number">Проверяемое число.</param>
        /// <param name="displayName">Отображаемое имя параметра, который проходит проверку.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void MoreThanZero(int number, string displayName)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"Параметр {displayName} не может быть меньше нуля.");
            }
        }
    }
}
