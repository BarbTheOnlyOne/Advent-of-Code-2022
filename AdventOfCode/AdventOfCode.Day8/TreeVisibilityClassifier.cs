using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    internal class TreeVisibilityClassifier
    {
        private readonly Tree[,] _treeMap;

        public int TreeMapRowCount { get; private set;}

        public int TreeMapColumnCount { get; private set;}

        public TreeVisibilityClassifier(Tree[,] treeMap)
        {
            _treeMap = treeMap;
            TreeMapRowCount = _treeMap.GetLength(0);
            TreeMapColumnCount = _treeMap.GetLength(1);
        }

        public void DoVisibilityClassification()
        {

        }


        /// <summary>
        ///     Sets the initial visibility of outer trees.
        ///     Meaning all top trees are visible from the top since they are on the edge, etc.
        /// </summary>
        /// <param name="treeMap"></param>
        public  void ClassifyOuterTrees(Tree[,] treeMap)
        {
            ClassifyTopAndBottom(treeMap);
            ClassifyRightAndLeft(treeMap);
        }

        public static void ClassifyInnerTreesFromLeft(Tree[,] treeMap)
        {
            for (int i = 1; i < treeMap.GetLength(0) - 1; i++) // gets the number of rows
            {
                for (int j = 1; j < treeMap.GetLength(1) -1; j++) // gets the number of columns
                {
                    var classifiedTree = treeMap[i, j];

                    var topTree = treeMap[i, j];
                    var bottomTree = treeMap[i, j];
                    var leftTree = treeMap[i, j];
                    var rightTree = treeMap[i, j];

                    // TODO
                }
            }
        }

        private void ClassifyOuterTopRow()
        {
            for (int i = 0; i < TreeMapColumnCount; i++)
            {
                var classifiedTree = _treeMap[0, i];
                classifiedTree.TopVisibility = Visibility.Visible;

            }
        }

        private  void ClassifyRightAndLeft(Tree[,] treeMap)
        {
            for (int i = 0; i < treeMap.GetLength(0); i++)
            {
                treeMap[i, 0].LeftVisibility = Visibility.Visible;
                treeMap[i, treeMap.GetLength(1)].RightVisibility = Visibility.Visible;
            }
        }

        private  void ClassifyTopAndBottom(Tree[,] treeMap)
        {
            for (int i = 0; i < treeMap.GetLength(1); i++)
            {
                treeMap[0, i].TopVisibility = Visibility.Visible;
                treeMap[0, i].BottomVisibility = treeMap[1, i].TreeHeight < treeMap[0, i].TreeHeight ? Visibility.Visible : Visibility.Hidden;

                treeMap[treeMap.GetLength(0), i].BottomVisibility = Visibility.Visible;
                treeMap[treeMap.GetLength(0), i].TopVisibility =
                    treeMap[treeMap.GetLength(0) - 1, i].TreeHeight < treeMap[treeMap.GetLength(0), i].TreeHeight ? Visibility.Visible : Visibility.Hidden;
            }
        }
    }
}
