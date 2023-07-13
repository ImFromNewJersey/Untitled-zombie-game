// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Jims/PlayerMasked"
{
	Properties
	{
		_Smoothness("_Smoothness", Range( 0 , 1)) = 0.2
		_ColourHair("_ColourHair", Color) = (0.1981132,0.1777026,0.1579299,1)
		_ColourHair2("_ColourHair2", Color) = (0.4433962,0.4011861,0.366011,1)
		_ColourSkin("_ColourSkin", Color) = (0.9568628,0.8313726,0.7098039,1)
		_ColourEyes("_ColourEyes", Color) = (0,0,0,1)
		_ColourMouth("_ColourMouth", Color) = (0.7735849,0.6679381,0.5655928,1)
		_ColourFaceHair("_ColourFaceHair", Color) = (0.1981132,0.1777026,0.1579299,1)
		_ColourUnderwearT("_ColourUnderwearT", Color) = (1,1,1,1)
		_ColourUnderwearB("_ColourUnderwearB", Color) = (0.1509434,0.1509434,0.1509434,1)
		[HideInInspector]_MaskHair("_MaskHair", 2D) = "white" {}
		[HideInInspector]_MaskHair2("_MaskHair2", 2D) = "white" {}
		[HideInInspector]_MaskSkin("_MaskSkin", 2D) = "white" {}
		[HideInInspector]_MaskEyes("_MaskEyes", 2D) = "white" {}
		[HideInInspector]_MaskMouth("_MaskMouth", 2D) = "white" {}
		[HideInInspector]_MaskFaceHair("_MaskFaceHair", 2D) = "white" {}
		[HideInInspector]_MaskUnderwearT("_MaskUnderwearT", 2D) = "white" {}
		[HideInInspector]_MaskUnderwearB("_MaskUnderwearB", 2D) = "white" {}
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
		uniform float4 _ColourHair;
		uniform sampler2D _MaskHair;
		uniform float4 _MaskHair_ST;
		uniform float4 _ColourHair2;
		uniform sampler2D _MaskHair2;
		uniform float4 _MaskHair2_ST;
		uniform float4 _ColourSkin;
		uniform sampler2D _MaskSkin;
		uniform float4 _MaskSkin_ST;
		uniform float4 _ColourEyes;
		uniform sampler2D _MaskEyes;
		uniform float4 _MaskEyes_ST;
		uniform float4 _ColourMouth;
		uniform sampler2D _MaskMouth;
		uniform float4 _MaskMouth_ST;
		uniform float4 _ColourFaceHair;
		uniform sampler2D _MaskFaceHair;
		uniform float4 _MaskFaceHair_ST;
		uniform float4 _ColourUnderwearT;
		uniform sampler2D _MaskUnderwearT;
		uniform float4 _MaskUnderwearT_ST;
		uniform float4 _ColourUnderwearB;
		uniform sampler2D _MaskUnderwearB;
		uniform float4 _MaskUnderwearB_ST;
		uniform float _Smoothness;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Texture = i.uv_texcoord * _Texture_ST.xy + _Texture_ST.zw;
			float2 uv_MaskHair = i.uv_texcoord * _MaskHair_ST.xy + _MaskHair_ST.zw;
			float temp_output_25_0_g4 = 0.5;
			float temp_output_22_0_g4 = step( tex2D( _MaskHair, uv_MaskHair, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g4 );
			float4 lerpResult20 = lerp( tex2D( _Texture, uv_Texture, float2( 0,0 ), float2( 0,0 ) ) , _ColourHair , temp_output_22_0_g4);
			float2 uv_MaskHair2 = i.uv_texcoord * _MaskHair2_ST.xy + _MaskHair2_ST.zw;
			float temp_output_25_0_g33 = 0.5;
			float temp_output_22_0_g33 = step( tex2D( _MaskHair2, uv_MaskHair2, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g33 );
			float4 lerpResult113 = lerp( lerpResult20 , _ColourHair2 , temp_output_22_0_g33);
			float2 uv_MaskSkin = i.uv_texcoord * _MaskSkin_ST.xy + _MaskSkin_ST.zw;
			float temp_output_25_0_g34 = 0.5;
			float temp_output_22_0_g34 = step( tex2D( _MaskSkin, uv_MaskSkin, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g34 );
			float4 lerpResult117 = lerp( lerpResult113 , _ColourSkin , temp_output_22_0_g34);
			float2 uv_MaskEyes = i.uv_texcoord * _MaskEyes_ST.xy + _MaskEyes_ST.zw;
			float temp_output_25_0_g35 = 0.5;
			float temp_output_22_0_g35 = step( tex2D( _MaskEyes, uv_MaskEyes, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g35 );
			float4 lerpResult121 = lerp( lerpResult117 , _ColourEyes , temp_output_22_0_g35);
			float2 uv_MaskMouth = i.uv_texcoord * _MaskMouth_ST.xy + _MaskMouth_ST.zw;
			float temp_output_25_0_g37 = 0.5;
			float temp_output_22_0_g37 = step( tex2D( _MaskMouth, uv_MaskMouth, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g37 );
			float4 lerpResult129 = lerp( lerpResult121 , _ColourMouth , temp_output_22_0_g37);
			float2 uv_MaskFaceHair = i.uv_texcoord * _MaskFaceHair_ST.xy + _MaskFaceHair_ST.zw;
			float temp_output_25_0_g36 = 0.5;
			float temp_output_22_0_g36 = step( tex2D( _MaskFaceHair, uv_MaskFaceHair, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g36 );
			float4 lerpResult125 = lerp( lerpResult129 , _ColourFaceHair , temp_output_22_0_g36);
			float2 uv_MaskUnderwearT = i.uv_texcoord * _MaskUnderwearT_ST.xy + _MaskUnderwearT_ST.zw;
			float temp_output_25_0_g38 = 0.5;
			float temp_output_22_0_g38 = step( tex2D( _MaskUnderwearT, uv_MaskUnderwearT, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g38 );
			float4 lerpResult133 = lerp( lerpResult125 , _ColourUnderwearT , temp_output_22_0_g38);
			float2 uv_MaskUnderwearB = i.uv_texcoord * _MaskUnderwearB_ST.xy + _MaskUnderwearB_ST.zw;
			float temp_output_25_0_g39 = 0.5;
			float temp_output_22_0_g39 = step( tex2D( _MaskUnderwearB, uv_MaskUnderwearB, float2( 0,0 ), float2( 0,0 ) ).r , temp_output_25_0_g39 );
			float4 lerpResult137 = lerp( lerpResult133 , _ColourUnderwearB , temp_output_22_0_g39);
			o.Albedo = lerpResult137.rgb;
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
288;6;1426;810;2795.28;1785.936;3.213297;True;False
Node;AmplifyShaderEditor.SamplerNode;17;-1758.436,-614.0737;Inherit;True;Property;_MaskHair;_MaskHair;9;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;e5172f9561b5b104eab4a54421b0143e;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;16;-1813.321,-1018.013;Inherit;True;Property;_Texture;Texture;17;1;[HideInInspector];Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;18;-1405.638,-633.4544;Inherit;False;MaskingFunction;-1;;4;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.SamplerNode;116;-995.924,-612.8552;Inherit;True;Property;_MaskHair2;_MaskHair2;10;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;8cad2dd697e20bc4baff714aba94e28a;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;19;-1720.038,-806.4643;Inherit;False;Property;_ColourHair;_ColourHair;1;0;Create;True;0;0;False;0;0.1981132,0.1777026,0.1579299,1;0.1981132,0.1777026,0.1579298,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;20;-1405.457,-800.7125;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;114;-643.126,-632.2359;Inherit;False;MaskingFunction;-1;;33;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.SamplerNode;120;-242.5731,-615.4619;Inherit;True;Property;_MaskSkin;_MaskSkin;11;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;cd95ab72febb22d498b296987e19de61;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;115;-957.526,-805.2458;Inherit;False;Property;_ColourHair2;_ColourHair2;2;0;Create;True;0;0;False;0;0.4433962,0.4011861,0.366011,1;0.4339623,0.3926502,0.3582236,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;119;-204.175,-807.8524;Inherit;False;Property;_ColourSkin;_ColourSkin;3;0;Create;True;0;0;False;0;0.9568628,0.8313726,0.7098039,1;0.9568627,0.8313726,0.7098039,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;118;110.225,-634.8425;Inherit;False;MaskingFunction;-1;;34;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.LerpOp;113;-642.9451,-799.494;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;124;492.3159,-609.0864;Inherit;True;Property;_MaskEyes;_MaskEyes;12;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;ecf37ecb20c1f394c8b8df51839238cf;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;123;530.7141,-801.4769;Inherit;False;Property;_ColourEyes;_ColourEyes;4;0;Create;True;0;0;False;0;0,0,0,1;0,0,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;122;845.1138,-628.467;Inherit;False;MaskingFunction;-1;;35;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.LerpOp;117;110.4059,-802.1006;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;132;-1802.811,-135.2858;Inherit;True;Property;_MaskMouth;_MaskMouth;13;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;2199534a39b1f0c47b03abe481897c9b;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;121;845.2947,-795.725;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;130;-1450.013,-154.6665;Inherit;False;MaskingFunction;-1;;37;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.ColorNode;131;-1764.413,-327.6763;Inherit;False;Property;_ColourMouth;_ColourMouth;5;0;Create;True;0;0;False;0;0.7735849,0.6679381,0.5655928,1;0.7735849,0.6679381,0.5655928,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;128;-1018.592,-137.9087;Inherit;True;Property;_MaskFaceHair;_MaskFaceHair;14;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;49324f1d0cccb24478f7cb28e2c18a31;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;126;-665.7944,-155.885;Inherit;False;MaskingFunction;-1;;36;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.ColorNode;127;-980.1941,-330.2992;Inherit;False;Property;_ColourFaceHair;_ColourFaceHair;6;0;Create;True;0;0;False;0;0.1981132,0.1777026,0.1579299,1;0.2735848,0.2334622,0.2000267,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;136;-263.7892,-135.9993;Inherit;True;Property;_MaskUnderwearT;_MaskUnderwearT;15;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;c9c57f721fa8bde4c900bdc1c53bb38d;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;129;-1449.832,-321.9246;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;135;-225.3911,-326.9854;Inherit;False;Property;_ColourUnderwearT;_ColourUnderwearT;7;0;Create;True;0;0;False;0;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;125;-665.6133,-323.143;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;140;471.0998,-129.6238;Inherit;True;Property;_MaskUnderwearB;_MaskUnderwearB;16;1;[HideInInspector];Create;True;0;0;False;0;e5172f9561b5b104eab4a54421b0143e;f142a77d7a6b5e244b454722cb385336;True;0;False;white;Auto;False;Object;-1;Derivative;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;134;89.00893,-155.3799;Inherit;False;MaskingFunction;-1;;38;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.LerpOp;133;89.18984,-322.6379;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;139;509.4982,-322.0143;Inherit;False;Property;_ColourUnderwearB;_ColourUnderwearB;8;0;Create;True;0;0;False;0;0.1509434,0.1509434,0.1509434,1;0.1792453,0.1792453,0.1792453,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;138;823.8979,-149.0043;Inherit;False;MaskingFunction;-1;;39;571aab6f8c08f1c4d9bd4012d2958d88;0;3;21;FLOAT;0;False;30;FLOAT;0;False;25;FLOAT;0.5;False;3;FLOAT;0;FLOAT;32;FLOAT;28
Node;AmplifyShaderEditor.RangedFloatNode;21;1473.381,-674.362;Inherit;False;Property;_Smoothness;_Smoothness;0;0;Create;True;0;0;False;0;0.2;0.2;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;137;824.0788,-316.2624;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1827.771,-617.4832;Float;False;True;2;ASEMaterialInspector;0;0;Standard;Jims/PlayerMasked;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;Standard;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;18;21;17;0
WireConnection;20;0;16;0
WireConnection;20;1;19;0
WireConnection;20;2;18;32
WireConnection;114;21;116;0
WireConnection;118;21;120;0
WireConnection;113;0;20;0
WireConnection;113;1;115;0
WireConnection;113;2;114;32
WireConnection;122;21;124;0
WireConnection;117;0;113;0
WireConnection;117;1;119;0
WireConnection;117;2;118;32
WireConnection;121;0;117;0
WireConnection;121;1;123;0
WireConnection;121;2;122;32
WireConnection;130;21;132;0
WireConnection;126;21;128;0
WireConnection;129;0;121;0
WireConnection;129;1;131;0
WireConnection;129;2;130;32
WireConnection;125;0;129;0
WireConnection;125;1;127;0
WireConnection;125;2;126;32
WireConnection;134;21;136;0
WireConnection;133;0;125;0
WireConnection;133;1;135;0
WireConnection;133;2;134;32
WireConnection;138;21;140;0
WireConnection;137;0;133;0
WireConnection;137;1;139;0
WireConnection;137;2;138;32
WireConnection;0;0;137;0
WireConnection;0;3;21;0
WireConnection;0;4;21;0
ASEEND*/
//CHKSM=557F65C97D29C518465825C93571450AE21CA8A2