ShaderTK - The Shader Toolkit library

The Shader Toolkit library is an experimental
shader generator for GLSL and GLSL ES.

ShaderTK allows you to write shaders in C# and compile
them to a specific GLSL version at runtime or compile time.

This approach offers several advantages:
1. A single shader can be compiled for different profiles:
legacy GLSL [110-120], core GLSL [130-440] or GLSL ES2/ES3.
2. Shaders are checked statically by the C# compiler. This
removes a large source of uncertainty and potential errors.
3. Rich shader metadata is extracted at compile time. This
can be used to simplify the communication between GLSL and
the application.

ShaderTK is pre-alpha quality software. What is implemented:
- GLSL structures
- GLSL uniforms, inputs and outputs
- vec2, vec3, vec4, mat4 data types

Critical features missing:
- Most GLSL operators
- Many GLSL data types (matYxZ)
- IL to GLSL translation
- GLSL function calls
- GLSL profiles