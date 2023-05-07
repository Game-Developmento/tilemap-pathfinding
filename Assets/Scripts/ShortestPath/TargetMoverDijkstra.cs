using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;


/**
 * This component moves its object towards a given target position.
 */
public class TargetMoverDijkstra : MonoBehaviour
{
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;

    [Tooltip("The speed by which the object moves towards the target, in meters (=grid units) per second")]
    [SerializeField] float speed = 2f;

    // [Tooltip("Maximum number of iterations before BFS algorithm gives up on finding a path")]
    // [SerializeField] int maxIterations = 1000;

    [Tooltip("The target position in world coordinates")]
    [SerializeField] Vector3Int targetInWorld;

    [Tooltip("The target position in grid coordinates")]
    [SerializeField] Vector3Int targetInGrid;

    protected bool atTarget;  // This property is set to "true" whenever the object has already found the target.

    public void SetTarget(Vector3Int newTarget)
    {
        if (targetInWorld != newTarget)
        {
            targetInWorld = newTarget;
            targetInGrid = newTarget;
            atTarget = false;
        }
    }

    public Vector3Int GetTarget()
    {
        return targetInWorld;
    }

    private TilemapWeightedGraph tilemapGraph = null;
    private float timeBetweenSteps;

    protected virtual void Start()
    {
        tilemapGraph = new TilemapWeightedGraph(tilemap, allowedTiles.Get());
        timeBetweenSteps = 1 / speed;
        StartCoroutine(MoveTowardsTheTarget());
    }

    IEnumerator MoveTowardsTheTarget()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(timeBetweenSteps);
            if (enabled && !atTarget)
                MakeOneStepTowardsTheTarget();
        }
    }

    private void MakeOneStepTowardsTheTarget()
    {
        Node<Vector3Int> startNode = new Node<Vector3Int>(tilemap.WorldToCell(transform.position));
        Node<Vector3Int> endNode = new Node<Vector3Int>(targetInGrid);
        Debug.Log(startNode.Id);
        Debug.Log(endNode.Id);
        List<Node<Vector3Int>> shortestPath = Dijkstra<Vector3Int>.FindShortestPath(tilemapGraph, startNode, endNode);
        Debug.Log("shortestPath = " + string.Join(", ", shortestPath.Select(node => node.Id.ToString())));
        if (shortestPath.Count >= 2)
        { // shortestPath contains both source and target.
            Node<Vector3Int> nextNode = shortestPath[1];
            Vector3Int nextPosition = nextNode.Id;
            transform.position = tilemap.GetCellCenterWorld(nextPosition);
        }
        else
        {
            atTarget = true;
        }
    }
}
