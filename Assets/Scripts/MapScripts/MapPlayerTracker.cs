using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Map
{
    public class MapPlayerTracker : MonoBehaviour
    {
        public bool lockAfterSelecting = false;
        public float enterNodeDelay = 1f;
        public MapManager mapManager;
        public MapView view;

        public static MapPlayerTracker Instance;

        public bool Locked { get; set; }
        [Header("Transer Info")]
        public TransferLevelInfo Info;

        [Header("Barron UI")]
        public Image Barons;
        public TextMeshProUGUI BaronText;
        public GameObject Button;

        private void Awake()
        {
            Instance = this;
        }

        public void SelectNode(MapNode mapNode)
        {
            if (Locked) return;

            // Debug.Log("Selected node: " + mapNode.Node.point);

            if (mapManager.CurrentMap.path.Count == 0)
            {
                // player has not selected the node yet, he can select any of the nodes with y = 0
                if (mapNode.Node.point.y == 0)
                    SendPlayerToNode(mapNode);
                else
                    PlayWarningThatNodeCannotBeAccessed();
            }
            else
            {
                Vector2Int currentPoint = mapManager.CurrentMap.path[mapManager.CurrentMap.path.Count - 1];
                Node currentNode = mapManager.CurrentMap.GetNode(currentPoint);

                if (currentNode != null && currentNode.outgoing.Any(point => point.Equals(mapNode.Node.point)))
                    SendPlayerToNode(mapNode);
                else
                    PlayWarningThatNodeCannotBeAccessed();
            }
        }

        private void SendPlayerToNode(MapNode mapNode)
        {
            if (Button != null) Button.SetActive(true);

            Locked = lockAfterSelecting;
            mapManager.CurrentMap.path.Add(mapNode.Node.point);
            mapManager.SaveMap();
            view.SetAttainableNodes();
            view.SetLineColors();
            mapNode.ShowSwirlAnimation();
            Info.Enemy = mapNode.SelectedBarrons;

            DOTween.Sequence().AppendInterval(enterNodeDelay).OnComplete(() => EnterNode(mapNode));
        }

        private static void EnterNode(MapNode mapNode)
        {
            // we have access to blueprint name here as well
            Debug.Log("Entering node: " + mapNode.Node.blueprintName + " of type: " + mapNode.Node.nodeType);
            // load appropriate scene with context based on nodeType:
            // or show appropriate GUI over the map: 
            // if you choose to show GUI in some of these cases, do not forget to set "Locked" in MapPlayerTracker back to false
            switch (mapNode.Node.nodeType)
            {
                case NodeType.MinorEnemy:
                    break;
                case NodeType.EliteEnemy:
                    break;
                case NodeType.RestSite:
                    break;
                case NodeType.Treasure:
                    break;
                case NodeType.Store:
                    break;
                case NodeType.Boss:
                    break;
                case NodeType.Mystery:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void HoveredNode(EnemyStats _Enemy)
        {
            if (Locked) return;

            Barons.sprite = _Enemy.BaronImage;
            BaronText.text = _Enemy.BaronName;
        }

        private void PlayWarningThatNodeCannotBeAccessed()
        {
            Debug.Log("Selected node cannot be accessed");
        }
    }
}