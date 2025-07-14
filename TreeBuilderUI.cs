using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TreeBuilderUI : MonoBehaviour
{
    [System.Serializable]
    public class TreeNode
    {
        public string label;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(string label)
        {
            this.label = label;
        }
    }

    [Header("Assign in Inspector")]
    public RectTransform treeContainer;
    public GameObject nodeButtonPrefab;
    public GameObject linePrefab;
    public float xSpacing = 150f; // Horizontal spacing between nodes
    public float ySpacing = 120f; // Vertical spacing between levels

    void Start()
    {
        // ✅ Example: build a static tree A→B,C→D,E,F
        TreeNode root = new TreeNode("A");
        root.left = new TreeNode("B");
        root.right = new TreeNode("C");
        root.left.left = new TreeNode("D");
        root.left.right = new TreeNode("E");
        root.right.right = new TreeNode("F");

        // ✅ Build the tree starting from root
        BuildTree(root, treeContainer, 0, 0, Screen.width / 2, null);
    }

    void BuildTree(TreeNode node, RectTransform parent, int depth, int index, float xPos, RectTransform parentNode)
    {
        if (node == null) return;

        // ✅ Instantiate node button
        GameObject newButton = Instantiate(nodeButtonPrefab, parent);

        // ✅ Set text safely
        Text text = newButton.GetComponentInChildren<Text>();
        if (text != null)
        {
            text.text = node.label;
        }
        else
        {
            Debug.LogWarning("No Text component found in Node Button prefab.");
        }

        RectTransform rect = newButton.GetComponent<RectTransform>();

        // ✅ Position node
        float yPos = -depth * ySpacing;
        rect.anchoredPosition = new Vector2(xPos, yPos);

        // ✅ Draw line to parent
        if (parentNode != null)
        {
            DrawLine(parent, parentNode.anchoredPosition, rect.anchoredPosition);
        }

        // ✅ Calculate child x positions
        float childOffset = xSpacing / (depth + 1); // Spread children
        BuildTree(node.left, parent, depth + 1, index * 2, xPos - childOffset, rect);
        BuildTree(node.right, parent, depth + 1, index * 2 + 1, xPos + childOffset, rect);
    }

    void DrawLine(RectTransform parent, Vector2 start, Vector2 end)
    {
        // ✅ Instantiate line prefab
        GameObject line = Instantiate(linePrefab, parent);
        RectTransform rect = line.GetComponent<RectTransform>();

        // ✅ Calculate direction and distance
        Vector2 direction = end - start;
        float distance = direction.magnitude;

        // ✅ Set line properties
        rect.pivot = new Vector2(0, 0.5f); // Pivot at start
        rect.sizeDelta = new Vector2(distance, 3f); // 3f = thickness
        rect.anchoredPosition = start;

        // ✅ Rotate line to connect nodes
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rect.localRotation = Quaternion.Euler(0, 0, angle); // Use localRotation for UI
    }
}
