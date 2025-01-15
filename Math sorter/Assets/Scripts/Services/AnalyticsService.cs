using Facebook.Unity;
using GameAnalyticsSDK;

public class AnalyticsService : Singleton<AnalyticsService>
{
   public bool IsAnalyticsLoaded  => _isGameAnalyticsLoaded && _isAppmetricaLoaded ;

   private bool _isGameAnalyticsLoaded = false;
   private bool _isAppmetricaLoaded = false;

   protected override void Awake()
   {
      base.Awake();
      GameAnalyticsSDK.GameAnalytics.Initialize();
      FB.Init();
      HandleGameAnalyticsLoaded();
      AppMetrica.Instance.OnActivation += HandleAppmetricaLoaded;
      SendGameStartEvent();
   }

   private void OnDisable()
   {
      AppMetrica.Instance.OnActivation -= HandleAppmetricaLoaded;
   }

   private void HandleAppmetricaLoaded(YandexAppMetricaConfig config)
   {
      _isAppmetricaLoaded = true;
   }

   private void HandleGameAnalyticsLoaded()
   {
      _isGameAnalyticsLoaded = true;
   }

   private void SendGameStartEvent()
   {
      AppMetrica.Instance.ReportEvent("game_started");
      AppMetrica.Instance.SendEventsBuffer();
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start,"game_started");
   }

   public void SendLevelStartEvent(int levelIndex)
   {
      AppMetrica.Instance.ReportEvent("level_start_"+levelIndex);
      AppMetrica.Instance.SendEventsBuffer();
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start,"level_start_"+levelIndex);
   }
   
   public void SendLevelCompleteEvent(int levelIndex)
   {
      AppMetrica.Instance.ReportEvent("level_complete_"+levelIndex);
      AppMetrica.Instance.SendEventsBuffer();
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete,"level_complete_"+levelIndex);
   }
   
   public void SendLevelFailedeEvent(int levelIndex)
   {
      AppMetrica.Instance.ReportEvent("level_failed_"+levelIndex);
      AppMetrica.Instance.SendEventsBuffer();
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail,"level_failed_"+levelIndex);
   }
}
