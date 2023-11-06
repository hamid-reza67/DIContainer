
var container = new MyDIContainer();
// register logger
//container.Register<ILogger, Logger>();
container.RegisterSingleton<ILogger, Logger>();

container.Register<ISMS, Kavehnegar>();
var kavehnegarSMS = container.Resolve<ISMS>();
kavehnegarSMS.SendSMS("09139992061", "This is a test SMS that sended by kavenegar.");


container.Register<ISMS, Melipayamak>();
var melipayamakSMS = container.Resolve<ISMS>();
melipayamakSMS.SendSMS("09388333589", "This is a test SMS that sended by Melipayamak.");


