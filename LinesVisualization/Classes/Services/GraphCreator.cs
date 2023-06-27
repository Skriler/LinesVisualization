using System;
using LinesVisualization.Classes.Data;
using Microsoft.Msagl.Drawing;

using Color = Microsoft.Msagl.Drawing.Color;

namespace LinesVisualization.Classes.Services
{
    public class GraphCreator
    {
        private static Random rand = new Random();

        private ApplicationSettings settings;

        private Dictionary<string, Color> groupColors;
        private List<Color> nodeColors;

        public GraphCreator(ApplicationSettings settings)
        {
            this.settings = settings;
            groupColors = new Dictionary<string, Color>();

            nodeColors = new List<Color>()
            {
                Color.Gold, Color.Chartreuse, Color.LightPink, Color.Plum, Color.HotPink,
                Color.Salmon, Color.Snow, Color.Lime, Color.Tomato, Color.LightSeaGreen,
                Color.Turquoise, Color.Brown, Color.GreenYellow, Color.LightSkyBlue, Color.Yellow,
                Color.Silver, Color.Crimson, Color.Orchid, Color.Peru, Color.Aquamarine,
                Color.Cyan, Color.DodgerBlue, Color.Teal, Color.Violet, Color.RosyBrown,
            };
        }

        public Graph CreateGraph(Dictionary<NodeObject, List<NodeObject>> similarObjects, string graphTitle = "Lines")
        {
            Graph graph = new Graph(graphTitle);
            Node currentNode;
            Edge currentEdge;
            Color currentColor;

            foreach (var item in similarObjects)
            {
                currentNode = graph.AddNode(item.Key.Name);

                if (groupColors.ContainsKey(item.Key.Group))
                {
                    currentColor = groupColors.GetValueOrDefault(item.Key.Group);
                }
                else
                {
                    currentColor = GetNewRandomColor(groupColors);
                    groupColors.Add(item.Key.Group, currentColor);
                }

                currentNode.Attr.FillColor = currentColor;
            }

            foreach (var item in similarObjects)
            {
                foreach (var nodeObject in item.Value)
                {
                    currentEdge = graph.Edges
                        .FirstOrDefault(x => x.Source == nodeObject.Name && x.Target == item.Key.Name);

                    if (currentEdge != null)
                        continue;

                    currentEdge = graph.AddEdge(item.Key.Name, nodeObject.Name);
                    currentEdge.Attr.ArrowheadAtSource = ArrowStyle.None;
                    currentEdge.Attr.ArrowheadAtTarget = ArrowStyle.None;
                }
            }

            return graph;
        }

        private Color GetNewRandomColor(Dictionary<string, Color> groupColors)
        {
            Color randColor;

            do
            {
                randColor = nodeColors[rand.Next(nodeColors.Count)];
            } while (groupColors.ContainsValue(randColor));

            return randColor;
        }
    }
}
