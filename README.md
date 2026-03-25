# Descripcion proyecto

Es un proyecto el cual tengo pensado convertir en api en un futuro cercano. Me enfoque en crear una estructura organizada, reutilizable y escalable.
Para que en un futuro los programadores puedan implementar sus propias maquinas de turing en proyectos complejos facilmente.
En el archivo de pruebas e dejado un menu, donde el usuario elige la maquina que quiere probar y los casos de prueba que quiera realizar.
Estas maquinas se encuentran construidas en la carpeta "Turing Machines". 

## Datos Extra:

* Excepciones: Se lanza al intentar consumir una input, si el estado inicial no se encuentra definido.
* StepInfo: Es null solo si no se a consumido ningun paso.
* EvaluateInput: Se llama multiples veces haste que el metodo Step le manda el estado "Rejected" entonces evalua si se a quedado en un estado de aceptacion.
* GetCintaCabezal: Devuelve la cinta desde el cabezal.
