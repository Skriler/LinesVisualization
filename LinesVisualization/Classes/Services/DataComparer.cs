using LinesVisualization.Classes.Data;

namespace LinesVisualization.Classes.Services
{
    public class DataComparer
    {
        private ApplicationSettings settings;

        public DataComparer(ApplicationSettings settings)
        {
            this.settings = settings;
        }

        public Dictionary<NodeObject, List<NodeObject>> GetSimilarObjects(string[] columnNames, List<NodeObject> objects)
        {
            int[,] amountOfSimilarCharacteristics = CompareObjects(columnNames, objects);

            var similarObjects = new Dictionary<NodeObject, List<NodeObject>>();
            List<NodeObject> currentSimilarObjectsList;

            for (int i = 0; i < amountOfSimilarCharacteristics.GetLength(0); ++i)
            {
                similarObjects.Add(objects[i], new List<NodeObject>());
                similarObjects.TryGetValue(objects[i], out currentSimilarObjectsList);

                for (int j = 0; j < amountOfSimilarCharacteristics.GetLength(1); ++j)
                {
                    if (amountOfSimilarCharacteristics[i, j] < settings.MinSimilarCharacteristicsAmount)
                        continue;

                    currentSimilarObjectsList?.Add(objects[j]);
                }
            }

            return similarObjects;
        }

        public int[,] CompareObjects(string[] columnNames, List<NodeObject> objects)
        {
            int objectsAmount = objects.Count;

            int[,] amountOfSimilarCharacteristics = new int[objectsAmount, objectsAmount];

            for (int i = 0; i < objectsAmount; ++i)
            {
                for (int j = 0; j < objectsAmount; ++j)
                {
                    if (i == j)
                        continue;

                    amountOfSimilarCharacteristics[i, j] =
                        GetAmountOfSimilarCharacteristics(
                            columnNames,
                            objects[i],
                            objects[j]
                            );
                }
            }

            return amountOfSimilarCharacteristics;
        }

        public int GetAmountOfSimilarCharacteristics(string[] characteristics, NodeObject firstObject, NodeObject secondObject)
        {
            if (firstObject.Count != characteristics.Length || secondObject.Count != characteristics.Length)
                throw new Exception("Objects have incorrect amount of characteristics");

            int similarCharacteristicsAmount = 0;
            bool isCharcActive;
            string currentCharacteristic;

            for (int i = 0; i < characteristics.Length; ++i)
            {
                currentCharacteristic = characteristics[i];

                settings.SelectedFields.TryGetValue(
                    currentCharacteristic,
                    out isCharcActive
                    );

                if (!isCharcActive)
                    continue;

                if (!IsCharacteristicsEquals(
                    firstObject[currentCharacteristic],
                    secondObject[currentCharacteristic]
                    ))
                    continue;

                ++similarCharacteristicsAmount;
            }

            return similarCharacteristicsAmount;
        }

        public bool IsCharacteristicsEquals(string firstCharc, string secondCharc)
        {
            double firstNumb;
            double secondNumb;

            bool isFirstCharcNumber = double.TryParse(firstCharc, out firstNumb);
            bool isSecondCharcNumber = double.TryParse(secondCharc, out secondNumb);

            if (isFirstCharcNumber && isSecondCharcNumber)
            {
                double minPossibleBorder = firstNumb * settings.MinPossibleCoeff;
                double maxPossibleBorder = firstNumb * settings.MaxPossibleCoeff;

                return minPossibleBorder <= secondNumb && secondNumb <= maxPossibleBorder;
            }
            else
            {
                return firstCharc == secondCharc;
            }
        }
    }
}
