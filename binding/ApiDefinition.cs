using System;
using MonoTouch.CoreBluetooth;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace Estimote 
{
	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconDelegate 
	{
		[Export ("beaconConnectionDidFail:withError:"), EventArgs("FailedWithError")]
		void FailedWithError (ESTBeacon beacon, NSError error);

		[Export ("beaconConnectionDidSucceeded:"), EventArgs("Succeeded")]
		void Succeeded (ESTBeacon beacon);

		[Export ("beaconDidDisconnect:withError:"), EventArgs("DisconnectedWithError")]
		void DisconnectedWithError (ESTBeacon beacon, NSError error);
	}

	public delegate void UnsignedCompletion(int value, NSError error);
	public delegate void StringCompletion(string value, NSError error);
	public delegate void Completion(NSError error);

	[BaseType (typeof (NSObject), 
		Delegates = new [] { "WeakDelegate" },
		Events = new [] { typeof(ESTBeaconDelegate)})]
	public partial interface ESTBeacon 
	{
		[Export ("firmwareState")]
		ESTBeaconFirmwareState FirmwareState { get; set; }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap("WeakDelegate")]
		ESTBeaconDelegate Delegate { get; set; }

		[Export ("peripheral", ArgumentSemantic.Retain)]
		CBPeripheral Peripheral { get; set; }

		[Export ("macAddress", ArgumentSemantic.Retain)]
		string MacAddress { get; set; }

		[Export ("measuredPower", ArgumentSemantic.Retain)]
		NSNumber MeasuredPower { get; set; }

		[Export ("major", ArgumentSemantic.Retain)]
		NSNumber Major { get; set; }

		[Export ("minor", ArgumentSemantic.Retain)]
		NSNumber Minor { get; set; }

		[Export ("rssi", ArgumentSemantic.Retain)]
		NSNumber Rssi { get; set; }

		[Export ("power", ArgumentSemantic.Retain)]
		NSNumber Power { get; set; }

		[Export ("frequency", ArgumentSemantic.Retain)]
		NSNumber Frequency { get; set; }

		[Export ("batteryLevel", ArgumentSemantic.Retain)]
		NSNumber BatteryLevel { get; set; }

		[Export ("hardwareVersion", ArgumentSemantic.Retain)]
		string HardwareVersion { get; set; }

		[Export ("firmwareVersion", ArgumentSemantic.Retain)]
		string FirmwareVersion { get; set; }

		[Export ("ibeacon", ArgumentSemantic.Retain)]
		CLBeacon IBeacon { get; set; }

		[Export ("isConnected")]
		bool IsConnected { get; }

		[Export ("connectToBeacon")]
		void ConnectToBeacon ();

		[Export ("disconnectBeacon")]
		void DisconnectBeacon ();

		[Export ("readBeaconMajorWithCompletion:")]
		void ReadBeaconMajorWithCompletion (UnsignedCompletion completion);

		[Export ("readBeaconMinorWithCompletion:")]
		void ReadBeaconMinorWithCompletion (UnsignedCompletion completion);

		[Export ("readBeaconFrequencyWithCompletion:")]
		void ReadBeaconFrequencyWithCompletion (UnsignedCompletion completion);

		[Export ("readBeaconPowerWithCompletion:")]
		void ReadBeaconPowerWithCompletion (UnsignedCompletion completion);

		[Export ("readBeaconBatteryWithCompletion:")]
		void ReadBeaconBatteryWithCompletion (UnsignedCompletion completion);

		[Export ("readBeaconFirmwareVersionWithCompletion:")]
		void ReadBeaconFirmwareVersionWithCompletion (StringCompletion completion);

		[Export ("readBeaconHardwareVersionWithCompletion:")]
		void ReadBeaconHardwareVersionWithCompletion (StringCompletion completion);

		[Export ("writeBeaconMajor:withCompletion:")]
		void WriteBeaconMajor (short major, UnsignedCompletion completion);

		[Export ("writeBeaconMinor:withCompletion:")]
		void WriteBeaconMinor (short minor, UnsignedCompletion completion);

		[Export ("writeBeaconFrequency:withCompletion:")]
		void WriteBeaconFrequency (short frequency, UnsignedCompletion completion);

		[Export ("writeBeaconPower:withCompletion:")]
		void WriteBeaconPower (ESTBeaconPower power, UnsignedCompletion completion);

		[Export ("updateBeaconFirmwareWithProgress:andCompletion:")]
		void UpdateBeaconFirmwareWithProgress (StringCompletion progress, Completion completion);
	}

	[BaseType (typeof (CLBeaconRegion))]
	public partial interface ESTBeaconRegion 
	{
		[Export ("initRegionWithIdentifier:")]
		IntPtr Constructor (string identifier);

		[Export ("initRegionWithMajor:identifier:")]
		IntPtr Constructor (int major, string identifier);

		[Export ("initRegionWithMajor:minor:identifier:")]
		IntPtr Constructor (int major, int minor, string identifier);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconManagerDelegate 
	{
		[Export ("beaconManager:didRangeBeacons:inRegion:"), EventArgs("DidRangeBeacons")]
		void DidRangeBeacons (ESTBeaconManager manager, ESTBeacon[] beacons, ESTBeaconRegion region);

		[Export ("beaconManager:rangingBeaconsDidFailForRegion:withError:"), EventArgs("RangingBeaconsDidFailForRegion")]
		void RangingBeaconsDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		[Export ("beaconManager:monitoringDidFailForRegion:withError:"), EventArgs("MonitoringDidFailForRegion")]
		void MonitoringDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		[Export ("beaconManager:didEnterRegion:"), EventArgs("DidEnterRegion")]
		void DidEnterRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		[Export ("beaconManager:didExitRegion:"), EventArgs("DidExitRegion")]
		void DidExitRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		[Export ("beaconManager:didDetermineState:forRegion:"), EventArgs("DidDetermineState")]
		void DidDetermineState (ESTBeaconManager manager, CLRegionState state, ESTBeaconRegion region);

		[Export ("beaconManagerDidStartAdvertising:error:"), EventArgs("OnError")]
		void Error (ESTBeaconManager manager, NSError beaconError);

		[Export ("beaconManager:didDiscoverBeacons:inRegion:"), EventArgs("DidDiscoverBeacons")]
		void DidDiscoverBeacons (ESTBeaconManager manager, ESTBeacon[] beacons, ESTBeaconRegion region);

		[Export ("beaconManager:didFailDiscoveryInRegion:"), EventArgs("DidFailDiscoveryInRegion")]
		void DidFailDiscoveryInRegion (ESTBeaconManager manager, ESTBeaconRegion region);
	}

	[BaseType (typeof (NSObject), 
		Delegates = new [] { "WeakDelegate" },
		Events = new [] { typeof(ESTBeaconManagerDelegate)})]
	public partial interface ESTBeaconManager 
	{
		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap("WeakDelegate")]
		ESTBeaconManagerDelegate Delegate { get; set; }

		[Export ("avoidUnknownStateBeacons")]
		bool AvoidUnknownStateBeacons { get; set; }

		[Export ("virtualBeaconRegion", ArgumentSemantic.Retain)]
		ESTBeaconRegion VirtualBeaconRegion { get; set; }

		[Export ("startRangingBeaconsInRegion:")]
		void StartRangingBeaconsInRegion (ESTBeaconRegion region);

		[Export ("startMonitoringForRegion:")]
		void StartMonitoringForRegion (ESTBeaconRegion region);

		[Export ("stopRangingBeaconsInRegion:")]
		void StopRangingBeaconsInRegion (ESTBeaconRegion region);

		[Export ("stopMonitoringForRegion:")]
		void StopMonitoringForRegion (ESTBeaconRegion region);

		[Export ("requestStateForRegion:")]
		void RequestStateForRegion (ESTBeaconRegion region);

		[Export ("startAdvertisingWithMajor:withMinor:withIdentifier:")]
		void StartAdvertisingWithMajor (int major, int minor, string identifier);

		[Export ("stopAdvertising")]
		void StopAdvertising ();

		[Export ("startEstimoteBeaconsDiscoveryForRegion:")]
		void StartEstimoteBeaconsDiscoveryForRegion (ESTBeaconRegion region);

		[Export ("stopEstimoteBeaconDiscovery")]
		void StopEstimoteBeaconDiscovery ();
	}
}
