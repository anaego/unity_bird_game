using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform pipe;
    public float pipeWidth;
    public float pipeMoveSpeed;
    public float pipeSpawnTimerMax;

    private const float CAMERA_ORTHO_SIZE = 50f;
    private const float PIPE_DESTROY_X_POSITION = -100f;
    private const float PIPE_SPAWN_X_POSITION = 100f;
    private const float BIRD_X_POSITION = 0f;

    private float pipeSpawnTimer;
    private float gapSize;
    private int pipesSpawned;
    private static Level instance;
    private int pipesPassedCount;

    private List<Transform> pipeList;

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard, 
        Impossible
    }

    private void Awake()
    {
        instance = this;
        pipeList = new List<Transform>();
        SetDifficulty(Difficulty.Easy);
    }

    private void Start()
    {
        //CreatePipe(50, 0, true);
        //CreatePipe(50, 10, false);
        //CreateGapPipes(50f, 20f, 30f);
    }

    private void Update()
    {
        HandlePipeMovement();
        HandlePipeSpawning();
    }

    private void HandlePipeMovement()
    {
        for (int i=0; i < pipeList.Count; i++)
        {
            Transform pipeTransform = pipeList[i];

            bool isToTheRightOfBird = pipeTransform.position.x > BIRD_X_POSITION;
            pipeTransform.position += new Vector3(-1, 0, 0) * pipeMoveSpeed * Time.deltaTime;
            if (isToTheRightOfBird && pipeTransform.position.x <= BIRD_X_POSITION)
            {
                pipesPassedCount++;
            }

            if (pipeTransform.position.x < PIPE_DESTROY_X_POSITION)
            {
                Destroy(pipeTransform.gameObject);
                pipeList.Remove(pipeTransform);
                i--;
            }
        }
    }

    private void HandlePipeSpawning()
    {
        pipeSpawnTimer -= Time.deltaTime;
        if (pipeSpawnTimer < 0)
        {
            pipeSpawnTimer += pipeSpawnTimerMax;
            float heightEdgeLimit = 10f;
            float minHeight = gapSize * 0.5f + heightEdgeLimit;
            float totalHeight = CAMERA_ORTHO_SIZE * 2f;
            float maxHeight = totalHeight - gapSize * 0.5f - heightEdgeLimit;
            float height = Random.Range(minHeight, maxHeight);
            CreateGapPipes(height, gapSize, PIPE_SPAWN_X_POSITION);
            Debug.Log("HEIGHT " + height);
        }
    }

    private void SetDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                gapSize = 50f;
                break;
            case Difficulty.Medium:
                gapSize = 40f;
                break;
            case Difficulty.Hard:
                gapSize = 30f;
                break;
            case Difficulty.Impossible:
                gapSize = 20f;
                break;
        }
    }

    private Difficulty GetDifficulty()
    {
        if (pipesSpawned >= 60) return Difficulty.Impossible;
        if (pipesSpawned >= 40) return Difficulty.Hard;
        if (pipesSpawned >= 20) return Difficulty.Medium;
        return Difficulty.Easy;
    }

    private void CreateGapPipes(float gapY, float gapSize, float xPosition)
    {
        CreatePipe(gapY - gapSize * 0.5f, xPosition, true);
        CreatePipe(CAMERA_ORTHO_SIZE * 2f - gapY - gapSize * 0.5f, xPosition, false);
        pipesSpawned++;
        SetDifficulty(GetDifficulty());
    }

    private void CreatePipe(float height, float xPosition, bool createOnBottom)
    {
        Transform pipe_instance = Instantiate(pipe);

        float pipeYPosition;
        if (createOnBottom)
        {
            pipeYPosition = -CAMERA_ORTHO_SIZE;
            pipe.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            pipeYPosition = +CAMERA_ORTHO_SIZE;
            pipe.localScale = new Vector3(1, -1, 1);
        }
        pipe.position = new Vector2(xPosition, pipeYPosition);
        pipeList.Add(pipe_instance);
        Debug.Log("Pipe added to list");

        SpriteRenderer pipeSpriteRenderer = pipe.GetComponent<SpriteRenderer>();
        pipeSpriteRenderer.size = new Vector2(pipeWidth, height);

        BoxCollider2D pipeBoxCollider = pipe.GetComponent<BoxCollider2D>();
        pipeBoxCollider.size = new Vector2(pipeWidth, height);
        pipeBoxCollider.offset = new Vector2(0, (height * 0.5f));
    }

    public int GetPipesSpawned()
    {
        return pipesSpawned;
    }

    public int GetPipesPassedCount()
    {
        return pipesPassedCount;
    }

    public static Level GetInstance()
    {
        return instance;
    }
}
