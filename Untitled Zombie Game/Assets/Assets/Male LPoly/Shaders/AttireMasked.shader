// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Jims/AttireMasked"
{
	Properties
	{
		_Smoothness("_Smoothness", Range( 0 , 1)) = 0.3183819
		_MaskColour1("_MaskColour1", Color) = (0.1509434,0.1509434,0.1509434,1)
		_MaskColour2("_MaskColour2", Color) = (0.3018868,0.3018868,0.3018868,1)
		_MaskColour3("_MaskColour3", Color) = (0.5188679,0.5188679,0.5188679,1)
		_MaskColour4("_MaskColour4", Color) = (0.7169812,0.7169812,0.7169812,1)
		[HideInInspector]_Mask1("_Mask1", 2D) = "white" {}
		[HideInInspector]_Mask2("_Mask2", 2D) = "white" {}
		[HideInInspector]_Mask3("_Mask3", 2D) = "white" {}
		[HideInInspector]_Mask4("_Mask4", 2D) = "white" {}
		[HideInInspector]_Texture("Texture", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Texture;
		uniform float4 _Texture_ST;
		uniform float4 _MaskColour1;
		uniform sampler2D _Mask1;
		uniform float4 _Mask1_ST;
		uniform float4 _MaskColour2;
		uniform sampler2D _Mask2;
		uniform float4 _Mask2_ST;
		uniform float4 _MaskColour3;
		uniform sampler2D _Mask3;
		uniform float4 _Mask3_ST;
		uniform float4 _MaskColour4;
		uniform sampler2D _Mask4;
		uniform float4 _Mask4_ST;
		uniform float _Smoothness;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Texture = i.uv_texcoord * _Texture_ST.xy + _Texture_ST.zw;
			float2 uv_Mask1 = i.uv_texcoord * _Mask1_ST.xy + _Mask1_ST.zw;
			float temp_output_25_0_g4 = 0.5;
			float temp_output_22_0_g4 = step( tex2D( _Mask1, uv_Mask1, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g4 );
			float4 lerpResult20 = lerp( tex2D( _Texture, uv_Texture, float2( 0,0 ), float2( 0,0 ) ) , _MaskColour1 , temp_output_22_0_g4);
			float2 uv_Mask2 = i.uv_texcoord * _Mask2_ST.xy + _Mask2_ST.zw;
			float temp_output_25_0_g10 = 0.5;
			float temp_output_22_0_g10 = step( tex2D( _Mask2, uv_Mask2, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g10 );
			float4 lerpResult31 = lerp( lerpResult20 , _MaskColour2 , temp_output_22_0_g10);
			float2 uv_Mask3 = i.uv_texcoord * _Mask3_ST.xy + _Mask3_ST.zw;
			float temp_output_25_0_g11 = 0.5;
			float temp_output_22_0_g11 = step( tex2D( _Mask3, uv_Mask3, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g11 );
			float4 lerpResult35 = lerp( lerpResult31 , _MaskColour3 , temp_output_22_0_g11);
			float2 uv_Mask4 = i.uv_texcoord * _Mask4_ST.xy + _Mask4_ST.zw;
			float temp_output_25_0_g12 = 0.5;
			float temp_output_22_0_g12 = step( tex2D( _Mask4, uv_Mask4, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g12 );
			float4 lerpResult39 = lerp( lerpResult35 , _MaskColour4 , temp_output_22_0_g12);
			o.Albedo = lerpResult39.rgb;
			float temp_output_21_0 = _Smoothness;
			o.Metallic = temp_output_21_0;
			o.Smoothness = temp_output_21_0;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Standard"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17101
477;63;1426;810;2102.939;1167.02;1.883515;True;False
Node;AmplifyShaderEditor.SamplerNode;17;-1447.724,-565.6008;Inherit;True;Property;_Mask1;_Mask1;5;1;[HideInInspector];Create;True;0;0;False;0;4335a01b4d178334d8b909b8e08206b2;None;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;18;-1139.247,-506.0962;Inherit;False;MaskingFunction;-1;;4;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.SamplerNode;16;-1475.303,-849.0085;Inherit;True;Property;_Texture;Texture;9;1;[HideInInspector];Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;32;-767.3969,-581.5536;Inherit;True;Property;_Mask2;_Mask2;6;1;[HideInInspector];Create;True;0;0;False;0;4bee2347ca80d8e4ba8b76396f9ea02a;None;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;19;-1141.083,-687.8688;Inherit;False;Property;_MaskColour1;_MaskColour1;1;0;Create;True;0;0;False;0;0.1509434,0.1509434,0.1509434,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;36;-1147.388,-179.0717;Inherit;True;Property;_Mask3;_Mask3;7;1;[HideInInspector];Create;True;0;0;False;0;61051127c6e9b9641a1cb3fe79f05e8f;None;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;30;-458.9202,-522.0486;Inherit;False;MaskingFunction;-1;;10;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.ColorNode;33;-460.7562,-703.8216;Inherit;False;Property;_MaskColour2;_MaskColour2;2;0;Create;True;0;0;False;0;0.3018868,0.3018868,0.3018868,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;20;-927.2513,-754.1265;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;34;-838.9113,-119.5664;Inherit;False;MaskingFunction;-1;;11;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.LerpOp;31;-246.9249,-770.0794;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;40;-440.8104,-186.9663;Inherit;True;Property;_Mask4;_Mask4;8;1;[HideInInspector];Create;True;0;0;False;0;55ebbe5c57c9d22438b33314f4f971ff;None;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;37;-840.7473,-301.3399;Inherit;False;Property;_MaskColour3;_MaskColour3;3;0;Create;True;0;0;False;0;0.5188679,0.5188679,0.5188679,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;38;-132.3331,-127.461;Inherit;False;MaskingFunction;-1;;12;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.ColorNode;41;-134.1692,-309.2344;Inherit;False;Property;_MaskColour4;_MaskColour4;4;0;Create;True;0;0;False;0;0.7169812,0.7169812,0.7169812,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;35;-587.3621,-369.4812;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;39;79.66193,-375.4923;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;21;-69.69572,-464.0364;Inherit;False;Property;_Smoothness;_Smoothness;0;0;Create;True;0;0;False;0;0.3183819;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;275.644,-581.6523;Float;False;True;2;ASEMaterialInspector;0;0;Standard;Jims/AttireMasked;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;Standard;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;18;21;17;0
WireConnection;30;21;32;0
WireConnection;20;0;16;0
WireConnection;20;1;19;0
WireConnection;20;2;18;32
WireConnection;34;21;36;0
WireConnection;31;0;20;0
WireConnection;31;1;33;0
WireConnection;31;2;30;32
WireConnection;38;21;40;0
WireConnection;35;0;31;0
WireConnection;35;1;37;0
WireConnection;35;2;34;32
WireConnection;39;0;35;0
WireConnection;39;1;41;0
WireConnection;39;2;38;32
WireConnection;0;0;39;0
WireConnection;0;3;21;0
WireConnection;0;4;21;0
ASEEND*/
//CHKSM=B01A1BC8D93BCC98F5AFCE824905E01767955A4B