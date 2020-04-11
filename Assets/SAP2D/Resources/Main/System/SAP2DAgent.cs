using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAP2D {

    [AddComponentMenu("Pathfinding 2D/SAP2D Agent")]
    public class SAP2DAgent : MonoBehaviour
    {
        public SAP2DPathfindingConfig Config;
        public Transform Target;

        [Space(10)]
        public bool CanMove = true;
        [Range(0, 1000)]
        public float MovementSpeed = 5;
        [Range(0, 1000)]
        public float RotationSpeed = 500;


        [HideInInspector]
        public bool isMoving;
        [HideInInspector]
        public int pathIndex; //current tile index
        [HideInInspector]
        public Vector3 posInGrid;

        [Space(10)]
        public bool CanSearch = true;
        public float PathUpdateRate = 0.15f;
        public float GetNextPointDistance = 0.1f;

        [Header("Debug")]
        public bool ShowGraphic = true;
        public Color32 color = new Color32(0, 213, 225, 255);

        [HideInInspector]
        private bool startPath = true;
        private bool wall;
        public Vector2[] path;     //array of path tiles
        private SAP2DPathfinder pathfinder;


        private SAP_GridSource grid;


        private void Start()
        {
            pathfinder = SAP2DPathfinder.singleton;
        }

        private void FixedUpdate()
        {
              
                grid = pathfinder.GetGrid(Config.GridIndex);
                posInGrid = grid.GetTileDataAtWorldPosition(transform.position).WorldPosition;

                if (transform.hasChanged)
                {
                    isMoving = true;
                    transform.hasChanged = false;
                }
                else
                {
                    isMoving = false;
                }

                if (GetNextPointDistance < 0)
                {
                    GetNextPointDistance = 0.01f;
                }
                if (!isMoving)
                {
                    wall = false;
                }

            if (startPath)
                StrapPath();
            if (CanMove)
                Move();

            
        }

        private IEnumerator FindPath()
        { //path loop update
            
            while (true)
            {
                if (CanSearch)
                {
                    if (grid.GetTileDataAtWorldPosition(transform.position).WorldPosition != grid.GetTileDataAtWorldPosition(Target.position).WorldPosition)
                    {
                    path = pathfinder.FindPath(transform.position, Target.position, Config);
                    pathIndex = 0;
                    wall = true;
                    }
                    yield return new WaitForSeconds(PathUpdateRate);

                }
                else
                {
                    wall = false;
                    yield return new WaitForSeconds(PathUpdateRate);
                }
                    
            }
        }

        void StrapPath()
        {
            StartCoroutine(FindPath());
            startPath = false;
        }
        private void Move()
        { //object movement
          
                Vector3 targetVector = grid.GetTileDataAtWorldPosition(Target.position).WorldPosition; //target tile position
                
                if (CanSearch == true && wall == true)
                {
                    if (transform.position != targetVector)
                    {
                        Vector3 currentTargetVector = grid.GetTileDataAtWorldPosition(path[pathIndex]).WorldPosition;
                        if (currentTargetVector == null)
                            CanSearch = false;

                            //Vector3 dir = currentTargetVector - transform.position; //direction of turn towards the current tile
                            //Rotate(dir);
                            transform.position = Vector2.MoveTowards(transform.position, currentTargetVector, Time.fixedDeltaTime * MovementSpeed);
                            if (Vector2.Distance(transform.position, currentTargetVector) < GetNextPointDistance)
                                if (pathIndex < path.Length - 1)                                                     
                                    pathIndex++;
                    }
                }
                if (!wall)
                {
                    if (transform.position != targetVector)
                    {
                        //Vector3 dir = targetVector - transform.position; //the direction of the turn towards the target
                        //Rotate(dir);
                        transform.position = Vector2.MoveTowards(transform.position, targetVector, Time.deltaTime * MovementSpeed);
                    }
                }
            
        }

        private void Rotate(Vector3 dir)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * RotationSpeed);
        }

        private bool isTargetWalkable()
        {
            return grid.GetTileDataAtWorldPosition(Target.position).isWalkable;
        }
    }
}

