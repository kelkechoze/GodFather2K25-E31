using System.Collections;
using System.Collections.Generic;
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
	/// Add this to a Cinemachine virtual camera and it'll let you control its near and far clipping planes
	/// </summary>
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachineClippingPlanesShaker")]
	#if MM_CINEMACHINE
	[RequireComponent(typeof(CinemachineVirtualCamera))]
<<<<<<< HEAD
=======
	#elif MM_CINEMACHINE3
	[RequireComponent(typeof(CinemachineCamera))]
>>>>>>> origin/Dev
	#endif
	public class MMCinemachineClippingPlanesShaker : MMShaker
	{
		[MMInspectorGroup("Clipping Planes", true, 45)]
		/// whether or not to add to the initial value
		public bool RelativeClippingPlanes = false;

		[MMInspectorGroup("Near Plane", true, 46)]
		/// the curve used to animate the intensity value on
		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeNear = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		/// the value to remap the curve's 0 to        
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapNearZero = 0.3f;
		/// the value to remap the curve's 1 to        
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapNearOne = 100f;

		[MMInspectorGroup("Far Plane", true, 47)]
		/// the curve used to animate the intensity value on
		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeFar = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		/// the value to remap the curve's 0 to        
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFarZero = 1000f;
		/// the value to remap the curve's 1 to        
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFarOne = 1000f;

		#if MM_CINEMACHINE
		protected CinemachineVirtualCamera _targetCamera;
<<<<<<< HEAD
=======
		#elif  MM_CINEMACHINE3
		protected CinemachineCamera _targetCamera;
		#endif
>>>>>>> origin/Dev
		protected float _initialNear;
		protected float _initialFar;
		protected float _originalShakeDuration;
		protected bool _originalRelativeClippingPlanes;
		protected AnimationCurve _originalShakeNear;
		protected float _originalRemapNearZero;
		protected float _originalRemapNearOne;
		protected AnimationCurve _originalShakeFar;
		protected float _originalRemapFarZero;
		protected float _originalRemapFarOne;

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
			float newNear = ShakeFloat(ShakeNear, RemapNearZero, RemapNearOne, RelativeClippingPlanes, _initialNear);
<<<<<<< HEAD
			_targetCamera.m_Lens.NearClipPlane = newNear;
			float newFar = ShakeFloat(ShakeFar, RemapFarZero, RemapFarOne, RelativeClippingPlanes, _initialFar);
			_targetCamera.m_Lens.FarClipPlane = newFar;
=======
			float newFar = ShakeFloat(ShakeFar, RemapFarZero, RemapFarOne, RelativeClippingPlanes, _initialFar);
			SetNearFar(newNear, newFar);
		}

		protected virtual void SetNearFar(float near, float far)
		{
			#if MM_CINEMACHINE
			_targetCamera.m_Lens.NearClipPlane = near;
			_targetCamera.m_Lens.FarClipPlane = far;
			#elif  MM_CINEMACHINE3
			_targetCamera.Lens.NearClipPlane = near;
			_targetCamera.Lens.FarClipPlane = far;
			#endif
>>>>>>> origin/Dev
		}

		/// <summary>
		/// Collects initial values on the target
		/// </summary>
		protected override void GrabInitialValues()
		{
<<<<<<< HEAD
			_initialNear = _targetCamera.m_Lens.NearClipPlane;
			_initialFar = _targetCamera.m_Lens.FarClipPlane;
=======
			#if MM_CINEMACHINE
			_initialNear = _targetCamera.m_Lens.NearClipPlane;
			_initialFar = _targetCamera.m_Lens.FarClipPlane;
			#elif  MM_CINEMACHINE3
			_initialNear = _targetCamera.Lens.NearClipPlane;
			_initialFar = _targetCamera.Lens.FarClipPlane;
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
		public virtual void OnMMCameraClippingPlanesShakeEvent(AnimationCurve animNearCurve, float duration, float remapNearMin, float remapNearMax, AnimationCurve animFarCurve, float remapFarMin, float remapFarMax, bool relativeValues = false,
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
				_originalShakeNear = ShakeNear;
				_originalShakeFar = ShakeFar;
				_originalRemapNearZero = RemapNearZero;
				_originalRemapNearOne = RemapNearOne;
				_originalRemapFarZero = RemapFarZero;
				_originalRemapFarOne = RemapFarOne;
				_originalRelativeClippingPlanes = RelativeClippingPlanes;
			}

<<<<<<< HEAD
			TimescaleMode = timescaleMode;
			ShakeDuration = duration;
			ShakeNear = animNearCurve;
			RemapNearZero = remapNearMin * feedbacksIntensity;
			RemapNearOne = remapNearMax * feedbacksIntensity;
			ShakeFar = animFarCurve;
			RemapFarZero = remapFarMin * feedbacksIntensity;
			RemapFarOne = remapFarMax * feedbacksIntensity;
			RelativeClippingPlanes = relativeValues;
			ForwardDirection = forwardDirection;
=======
			if (!OnlyUseShakerValues)
			{
				TimescaleMode = timescaleMode;
				ShakeDuration = duration;
				ShakeNear = animNearCurve;
				RemapNearZero = remapNearMin * feedbacksIntensity;
				RemapNearOne = remapNearMax * feedbacksIntensity;
				ShakeFar = animFarCurve;
				RemapFarZero = remapFarMin * feedbacksIntensity;
				RemapFarOne = remapFarMax * feedbacksIntensity;
				RelativeClippingPlanes = relativeValues;
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
			_targetCamera.m_Lens.NearClipPlane = _initialNear;
			_targetCamera.m_Lens.FarClipPlane = _initialFar;
=======
			SetNearFar(_initialNear, _initialFar);
>>>>>>> origin/Dev
		}

		/// <summary>
		/// Resets the shaker's values
		/// </summary>
		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalShakeDuration;
			ShakeNear = _originalShakeNear;
			ShakeFar = _originalShakeFar;
			RemapNearZero = _originalRemapNearZero;
			RemapNearOne = _originalRemapNearOne;
			RemapFarZero = _originalRemapFarZero;
			RemapFarOne = _originalRemapFarOne;
			RelativeClippingPlanes = _originalRelativeClippingPlanes;
		}

		/// <summary>
		/// Starts listening for events
		/// </summary>
		public override void StartListening()
		{
			base.StartListening();
			MMCameraClippingPlanesShakeEvent.Register(OnMMCameraClippingPlanesShakeEvent);
		}

		/// <summary>
		/// Stops listening for events
		/// </summary>
		public override void StopListening()
		{
			base.StopListening();
			MMCameraClippingPlanesShakeEvent.Unregister(OnMMCameraClippingPlanesShakeEvent);
		}
<<<<<<< HEAD
		#endif
=======
>>>>>>> origin/Dev
	}
}