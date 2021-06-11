Shader "AudioDebug/Unlit/Gizmo"
{
	Properties
	{
		_Color("_Color", Color) = (1,1,1,1)
		_Line("_Line", Range(0.0001, 0.2)) = 0.001
		_MinAlpha("_MinAlpha", Range(0, 1)) = 0
	}
		SubShader
	{
		Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
		ZWrite Off
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "Gizmo.hlsl"
			ENDCG
		}
	}
}
