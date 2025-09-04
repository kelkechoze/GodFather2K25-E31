using UnityEngine;
using MoreMountains.Feedbacks;
#if MM_CINEMACHINE
using Cinemachine;
<<<<<<< HEAD
#endif
=======
#elif MM_CINEMACHINE3
using Unity.Cinemachine;
#endif
using UnityEngine.Scripting.APIUpdating;
>>>>>>> origin/Dev

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
<<<<<<< HEAD
	#if MM_CINEMACHINE
	[FeedbackPath("Camera/Cinemachine Impulse Source")]
	#endif
=======
	#if MM_CINEMACHINE || MM_CINEMACHINE3
	[FeedbackPath("Camera/Cinemachine Impulse Source")]
	#endif
	[MovedFrom(false, null, "MoreMountains.Feedbacks.Cinemachine")]
>>>>>>> origin/Dev
	[FeedbackHelp("This feedback lets you generate an impulse on a Cinemachine Impulse source. You'll need a Cinemachine Impulse Listener on your camera for this to work.")]
	public class MMF_CinemachineImpulseSource : MMF_Feedback
	{
		/// a static bool used to disable all feedbacks of this type at once
		public static bool FeedbackTypeAuthorized = true;
		/// sets the inspector color for this feedback
		#if UNITY_EDITOR
			public override Color FeedbackColor { get { return MMFeedbacksInspectorColors.CameraColor; } }
<<<<<<< HEAD
			#if MM_CINEMACHINE
=======
			#if MM_CINEMACHINE || MM_CINEMACHINE3
>>>>>>> origin/Dev
				public override bool EvaluateRequiresSetup() { return (ImpulseSource == null); }
				public override string RequiredTargetText { get { return ImpulseSource != null ? ImpulseSource.name : "";  } }
			#endif
			public override string RequiresSetupText { get { return "This feedback requires that an ImpulseSource be set to be able to work properly. You can set one below."; } }
		#endif
		

		[MMFInspectorGroup("Cinemachine Impulse Source", true, 28)]

		/// the velocity to apply to the impulse shake
		[Tooltip("the velocity to apply to the impulse shake")]
		public Vector3 Velocity = new Vector3(1f,1f,1f);
<<<<<<< HEAD
		#if MM_CINEMACHINE
=======
		#if MM_CINEMACHINE || MM_CINEMACHINE3
>>>>>>> origin/Dev
			/// the impulse definition to broadcast
			[Tooltip("the impulse definition to broadcast")]
			public CinemachineImpulseSource ImpulseSource;
			
			public override bool HasAutomatedTargetAcquisition => true;
			protected override void AutomateTargetAcquisition() => ImpulseSource = FindAutomatedTarget<CinemachineImpulseSource>();
		#endif
		/// whether or not to clear impulses (stopping camera shakes) when the Stop method is called on that feedback
		[Tooltip("whether or not to clear impulses (stopping camera shakes) when the Stop method is called on that feedback")]
		public bool ClearImpulseOnStop = false;
        
		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1.0f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}

<<<<<<< HEAD
			#if MM_CINEMACHINE
=======
			#if MM_CINEMACHINE || MM_CINEMACHINE3
>>>>>>> origin/Dev
			if (ImpulseSource != null)
			{
				ImpulseSource.GenerateImpulse(Velocity);
			}
			#endif
		}

		/// <summary>
		/// Stops the animation if needed
		/// </summary>
		/// <param name="position"></param>
		/// <param name="feedbacksIntensity"></param>
		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1)
		{
			if (!Active || !FeedbackTypeAuthorized || !ClearImpulseOnStop)
			{
				return;
			}
			base.CustomStopFeedback(position, feedbacksIntensity);
            
<<<<<<< HEAD
			#if MM_CINEMACHINE
			CinemachineImpulseManager.Instance.Clear();
=======
			#if MM_CINEMACHINE || MM_CINEMACHINE3
				CinemachineImpulseManager.Instance.Clear();
>>>>>>> origin/Dev
			#endif
		}
		
		/// <summary>
		/// On restore, we put our object back at its initial position
		/// </summary>
		protected override void CustomRestoreInitialValues()
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
            
<<<<<<< HEAD
			#if MM_CINEMACHINE
			CinemachineImpulseManager.Instance.Clear();
=======
			#if MM_CINEMACHINE || MM_CINEMACHINE3
				CinemachineImpulseManager.Instance.Clear();
>>>>>>> origin/Dev
			#endif
		}
	}
}