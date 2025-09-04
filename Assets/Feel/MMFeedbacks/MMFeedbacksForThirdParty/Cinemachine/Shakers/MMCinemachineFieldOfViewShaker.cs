using UnityEngine;
#if MM_CINEMACHINE
using Cinemachine;
<<<<<<< HEAD
=======
#elif MM_CINEMACHINE3
using Unity.Cinemachine;
>>>>>>> origin/Dev
#endif
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

namespace MoreMountains.FeedbacksForThirdParty
{
	/// <summary>
	/// Add this to a Cinemachine virtual camera and it'll let you control its field of view over time, can be piloted by a MMFeedbackCameraFieldOfView
	/// </summary>
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachineFieldOfViewShaker")]
	#if MM_CINEMACHINE
	[RequireComponent(typeof(CinemachineVirtualCamera))]
<<<<<<< HEAD
=======
	#elif MM_CINEMACHINE3
	[RequireComponent(typeof(CinemachineCamera))]
>>>>>>> origin/Dev
	#endif
	public class MMCinemachineFieldOfViewShaker : MMShaker
	{
		[MMInspectorGroup("Field of view", true, 41)]
		/// whether or not to add to the initial value
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeFieldOfView = false;
		/// the curve used to animate the intensity value on
		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeFieldOfView = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		/// the value to remap the curve's 0 to
		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 179f)]
		public float RemapFieldOfViewZero = 60f;
		/// the value to remap the curve's 1 to
		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 179f)]
		public float RemapFieldOfViewOne = 120f;

		#if MM_CINEMACHINE
		protected CinemachineVirtualCamera _targetCamera;
<<<<<<< HEAD
=======
		#elif  MM_CINEMACHINE3
		protected CinemachineCamera _targetCamera;
		#endif
>>>>>>> origin/Dev
		protected float _initialFieldOfView;
		protected float _originalShakeDuration;
		protected bool _originalRelativeFieldOfView;
		protected AnimationCurve _originalShakeFieldOfView;
		protected float _originalRemapFieldOfViewZero;
		protected float _originalRemapFieldOfViewOne;

		/// <summary>
		/// On init we initialize our values
		/// </summary>
		protected override void Initialization()
		{
			base.Initialization();
<<<<<<< HEAD
			_targetCamera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
=======
			#if MM_CINEMACHINE
			_targetCamera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
			#elif  MM_CINEMACHINE3
			_targetCamera = this.gameObject.GetComponent<CinemachineCamera>();
			#endif
>>>>>>> origin/Dev
		}

		/// <summary>
		/// When that shaker gets added, we initialize its shake duration
		/// </summary>
		protected virtual void Reset()
		{
			ShakeDuration = 0.5f;
		}

		/// <summary>
		/// Shakes values over time
		/// </summary>
		protected override void Shake()
		{
			float newFieldOfView = ShakeFloat(ShakeFieldOfView, RemapFieldOfViewZero, RemapFieldOfViewOne, RelativeFieldOfView, _initialFieldOfView);
<<<<<<< HEAD
			_targetCamera.m_Lens.FieldOfView = newFieldOfView;
=======
			SetFieldOfView(newFieldOfView);
		}

		protected virtual void SetFieldOfView(float newFieldOfView)
		{
			#if MM_CINEMACHINE
			_targetCamera.m_Lens.FieldOfView = newFieldOfView;
			#elif  MM_CINEMACHINE3
			_targetCamera.Lens.FieldOfView = newFieldOfView;
			#endif
>>>>>>> origin/Dev
		}

		/// <summary>
		/// Collects initial values on the target
		/// </summary>
		protected override void GrabInitialValues()
		{
<<<<<<< HEAD
			_initialFieldOfView = _targetCamera.m_Lens.FieldOfView;
=======
			#if MM_CINEMACHINE
			_initialFieldOfView = _targetCamera.m_Lens.FieldOfView;
			#elif  MM_CINEMACHINE3
			_initialFieldOfView = _targetCamera.Lens.FieldOfView;
			#endif
>>>>>>> origin/Dev
		}

		/// <summary>
		/// When we get the appropriate event, we trigger a shake
		/// </summary>
		/// <param name="distortionCurve"></param>
		/// <param name="duration"></param>
		/// <param name="amplitude"></param>
		/// <param name="relativeDistortion"></param>
		/// <param name="feedbacksIntensity"></param>
		/// <param name="channel"></param>
		public virtual void OnMMCameraFieldOfViewShakeEvent(AnimationCurve distortionCurve, float duration, float remapMin, float remapMax, bool relativeDistortion = false,
			float feedbacksIntensity = 1.0f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, 
			TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
			if (!CheckEventAllowed(channelData))
			{
				return;
			}
            
			if (stop)
			{
				Stop();
				return;
			}

			if (restore)
			{
				ResetTargetValues();
				return;
			}
            
			if (!Interruptible && Shaking)
			{
				return;
			}
            
			_resetShakerValuesAfterShake = resetShakerValuesAfterShake;
			_resetTargetValuesAfterShake = resetTargetValuesAfterShake;

			if (resetShakerValuesAfterShake)
			{
				_originalShakeDuration = ShakeDuration;
				_originalShakeFieldOfView = ShakeFieldOfView;
				_originalRemapFieldOfViewZero = RemapFieldOfViewZero;
				_originalRemapFieldOfViewOne = RemapFieldOfViewOne;
				_originalRelativeFieldOfView = RelativeFieldOfView;
			}

<<<<<<< HEAD
			TimescaleMode = timescaleMode;
			ShakeDuration = duration;
			ShakeFieldOfView = distortionCurve;
			RemapFieldOfViewZero = remapMin * feedbacksIntensity;
			RemapFieldOfViewOne = remapMax * feedbacksIntensity;
			RelativeFieldOfView = relativeDistortion;
			ForwardDirection = forwardDirection;
=======
			if (!OnlyUseShakerValues)
			{
				TimescaleMode = timescaleMode;
				ShakeDuration = duration;
				ShakeFieldOfView = distortionCurve;
				RemapFieldOfViewZero = remapMin * feedbacksIntensity;
				RemapFieldOfViewOne = remapMax * feedbacksIntensity;
				RelativeFieldOfView = relativeDistortion;
				ForwardDirection = forwardDirection;
			}
>>>>>>> origin/Dev

			Play();
		}

		/// <summary>
		/// Resets the target's values
		/// </summary>
		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
<<<<<<< HEAD
			_targetCamera.m_Lens.FieldOfView = _initialFieldOfView;
=======
			SetFieldOfView(_initialFieldOfView);
>>>>>>> origin/Dev
		}

		/// <summary>
		/// Resets the shaker's values
		/// </summary>
		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalShakeDuration;
			ShakeFieldOfView = _originalShakeFieldOfView;
			RemapFieldOfViewZero = _originalRemapFieldOfViewZero;
			RemapFieldOfViewOne = _originalRemapFieldOfViewOne;
			RelativeFieldOfView = _originalRelativeFieldOfView;
		}

		/// <summary>
		/// Starts listening for events
		/// </summary>
		public override void StartListening()
		{
			base.StartListening();
			MMCameraFieldOfViewShakeEvent.Register(OnMMCameraFieldOfViewShakeEvent);
		}

		/// <summary>
		/// Stops listening for events
		/// </summary>
		public override void StopListening()
		{
			base.StopListening();
			MMCameraFieldOfViewShakeEvent.Unregister(OnMMCameraFieldOfViewShakeEvent);
		}
<<<<<<< HEAD
		#endif
=======
>>>>>>> origin/Dev
	}
}