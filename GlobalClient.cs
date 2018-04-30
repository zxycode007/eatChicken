using UnityEngine;
using System.Collections;

public class GlobalClient
{

    public static GlobalClient Instance;


    protected CameraController mCamController;
    protected GameStateController mGameStateController;
    protected ObjectPoolManager mObjectPoolManager;
    protected GameEventManager mGameEventManager;
    protected EntityManager mEntityManager;
    protected TimeManager mTimeManager;

    public CameraController cameraController { get { return mCamController; } }
    public GameStateController gameStateController { get { return mGameStateController; } }
    public ObjectPoolManager objPoolManager { get { return objPoolManager; } }
    public GameEventManager eventManager { get { return mGameEventManager; } }
    public EntityManager entityManager { get { return mEntityManager; } }
    public TimeManager timeManager { get { return mTimeManager; } }




    public GlobalClient()
    {
        Instance = this;
    }

    public void Initialze()
    {
        mCamController = new CameraController();
        mGameStateController = new GameStateController();
    }

    public long GetCurrentTicks()
    {
        return System.Environment.TickCount;
    }

    public IEntity GetUserEntity()
    {
        return entityManager.GetCurEntity();
    }
   
    public void Update()
    {
        eventManager.Update();
        gameStateController.Update();
        mCamController.Update();
        objPoolManager.Update();
    }

    
}
