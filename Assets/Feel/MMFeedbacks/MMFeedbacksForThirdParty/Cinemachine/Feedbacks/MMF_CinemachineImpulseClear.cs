<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
#if MM_CINEMACHINE
using Cinemachine;
#endif
=======
﻿using UnityEngine;
using MoreMountains.Feedbacks;
#if MM_CINEMACHINE
using Cinemachine;
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
	[FeedbackPath("Camera/Cinemachine Impulse Clear")]
	#endif
=======
	#if MM_CINEMACHINE || MM_CINEMACHINE3
	[FeedbackPath("Camera/Cinemachine Impulse Clear")]
	#endif
	[MovedFrom(false, null, "MoreMountains.Feedbacks.Cinemachine")]
>>>>>>> origin/Dev
	[FeedbackHelp("This feedback lets you trigger a Cinemachine Impulse clear, stopping instantly any impulse that may be playing.")]
	public class MMF_CinemachineImpulseClear : MMF_Feedback
	{
		/// a static bool used to disable all feedbacks of this type at once
		public static bool FeedbackTypeAuthorized = true;
		/// sets the inspector color for this feedback
		#if UNITY_EDITOR
		public override Color FeedbackColor { get { return MMFeedbacksInspectorColors.CameraColor; } }
		#endif

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
			CinemachineImpulseManager.Instance.Clear();
			#endif
		}
	}
}