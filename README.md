# 🚀 Sistema de Gestión de Semilleros Tecnológicos
### Proyecto Final de Desarrollo de Software - Trimestre VII
**Centro para la Industria Petroquímica - SENA**

---

## 👥 Equipo de Desarrollo e Integrantes
* **Andrés Martínez** - Desarrollador Backend & DBA
* **Eduar Llorente** - Desarrollador Frontend & Diseñador UI
* **Maikol Castellón** - Analista de Requisitos & QA

**Instructora Evaluadora:** Maristela Pérez

---

## 📝 ¿De qué trata el Proyecto en General?

El **Sistema de Gestión de Semilleros Tecnológicos** es una plataforma web integral diseñada con el objetivo de automatizar, estructurar y hacer un seguimiento riguroso a toda la actividad investigativa, académica y administrativa de los semilleros de investigación dentro del SENA. 

En el ámbito académico tradicional, la gestión de semilleros suele fragmentarse en múltiples archivos de Excel, actas físicas y cadenas de correos electrónicos, lo que ocasiona pérdida de trazabilidad. Esta solución unifica en un solo ecosistema digital la administración de proyectos, el control de cronogramas por fases, la asignación de tareas individuales, el agendamiento de reuniones, la organización de eventos institucionales y la vinculación de patrocinadores externos que financian la investigación.

---

## 👥 Perfiles de Usuario y Roles en la Plataforma

Para garantizar la seguridad y la correcta división de responsabilidades, el sistema opera bajo una arquitectura de **Autorización basada en Roles**, permitiendo que cada actor interactúe con los módulos que le corresponden:

### 1. Rol: Administrador del Sistema (Global)
Es el usuario con el nivel más alto de privilegios. Sus funciones principales incluyen:
* **Gestión Institucional:** Registrar, actualizar y dar de baja (lógica) los diferentes semilleros de investigación de la institución.
* **Control de Usuarios:** Crear las credenciales de acceso para los Líderes de Semillero e Investigadores, administrando sus permisos.
* **Gobierno de Patrocinadores:** Registrar las entidades (públicas o privadas) y personas naturales que aportan recursos económicos, controlando los montos de sus aportes.
* **Auditoría Exclusiva:** Acceder al módulo de reportes gerenciales para supervisar el rendimiento global de la plataforma (reportes consolidados de usuarios, semilleros, proyectos y eventos).

### 2. Rol: Líder de Semillero (Docente / Instructor)
Es el encargado de dirigir un semillero específico. Su interfaz está personalizada para:
* **Control de Proyectos:** Registrar nuevas propuestas de investigación y transformarlas en proyectos activos.
* **Planificación Ágil:** Estructurar el proyecto dividiéndolo en **Fases** cronológicas y desglosando estas fases en **Actividades** asignadas a los investigadores.
* **Gestión de Espacios:** Agendar y gestionar reuniones (virtuales o presenciales) con su equipo de trabajo.
* **Apropiación Social:** Registrar los eventos en los que participará el semillero y vincular los proyectos del semillero a dichos eventos para visibilizar los resultados.

### 3. Rol: Investigador (Aprendiz / Estudiante)
Es el motor operativo de la investigación. Su perfil le permite:
* **Ejecución de Tareas:** Visualizar el tablero de actividades asignadas dentro del proyecto, actualizando el estado de su avance en tiempo real.
* **Consultas Inteligentes:** Utilizar el motor de búsqueda avanzado para filtrar el histórico de actividades, agendas, eventos y compromisos mediante criterios cronológicos específicos (búsquedas precisas por una fecha exacta, por bloques de horas o agrupadas por mes y año).

---

## 🛠️ Arquitectura Tecnológica y Stack de Desarrollo

El sistema fue construido siguiendo las mejores prácticas de la industria del software, seleccionando tecnologías robustas que garantizan estabilidad en entornos de producción corporativos:

* **Capa de Presentación e Interfaz (Frontend):** Diseñado con vistas dinámicas utilizando el motor de plantillas **Razor (.cshtml)** de ASP.NET, maquetado de forma *responsive* para asegurar una visualización óptima en navegadores líderes como Google Chrome, Mozilla Firefox y Microsoft Edge.
* **Capa de Lógica de Negocio (Backend):** Programado en el lenguaje **C#** bajo el framework **.NET / ASP.NET MVC**. Se implementó el patrón de diseño arquitectónico de separación de capas (Modelos, Vistas, Controladores y Servicios) para facilitar la escalabilidad del código.
* **Capa de Almacenamiento (Base de Datos):** Gestionado en **SQL Server**. Toda la persistencia de datos cuenta con integridad referencial estricta, llaves foráneas bien estructuradas, restricciones `CHECK` personalizadas y un diseño normalizado para evitar la redundancia de datos.
* **Seguridad y Acceso:** Implementación de **ASP.NET Identity** para el manejo seguro de sesiones, expiración automática por inactividad y protección contra ataques comunes de la web como la inyección SQL y la falsificación de solicitudes entre sitios (Anti-CSRF Tokens).

---

## 🔍 ¿Qué hace el Módulo de Control de Calidad Interno del Software?

La instructora **Maristela Pérez** evalúa la calidad del comportamiento del sistema. Por ello, el software no es solo un formulario que guarda texto; el código integra un riguroso **Módulo de Control de Calidad de Datos Interno** que valida y protege el sistema de forma automática ante cualquier acción del usuario:

### 1. Ciclos de Vida y Máquinas de Estado Automatizadas
El sistema impide que los usuarios ingresen datos ilógicos que corrompan el negocio. Para lograrlo, los flujos transaccionales están blindados con estados iniciales obligatorios que se controlan desde la base de datos:
* **Reuniones:** Cuando se registra una reunión, el software la guarda automáticamente en estado **'Programada'**. El líder, según el cumplimiento de la agenda, es el único autorizado para mutarla a **'Realizada'**, **'Reprogramada'** o **'Cancelada'**.
* **Eventos:** Nacen como **'Programado'** y avanzan de forma lógica a **'En Progreso'**, **'Realizado'** o se suspenden como **'Cancelado'** / **'Aplazado'**.
* **Proyectos:** Inician su ciclo de vida como una **'Propuesta'** en evaluación. Al ser aprobados pasan a **'En Desarrollo'**, concluyen en **'Finalizado'** o se detienen en **'Suspendido'**.
* **Fases y Actividades:** Siguen un flujo de control de proyectos estructurado (**'Planeada'**, **'En Ejecución'**, **'Completada'**, **'Bloqueada'** para fases; y **'Pendiente'**, **'En Progreso'**, **'En Pruebas'**, **'Terminada'** para actividades), permitiendo medir el rendimiento exacto de los investigadores.

### 2. Mecanismo de Borrado Lógico (*Soft Delete Empresarial*)
Para cumplir con los más altos estándares de calidad, **el borrado físico (`DELETE`) está completamente prohibido** en las entidades principales del sistema (Semilleros, Usuarios, Eventos y Patrocinadores). 
* Cuando un Administrador o Líder decide "Eliminar" un registro, el backend ejecuta una instrucción `UPDATE` que cambia la columna **`estadoRegistro` de `1` (Activo) a `0` (Inactivo)**.
* Esto causa que el registro se oculte inmediatamente de las interfaces del usuario, simulando una eliminación completa.
* **Beneficio de Calidad:** Protege la integridad referencial de la base de datos. Si se borrara físicamente a un usuario o un patrocinador, todos los proyectos antiguos, reportes financieros y registros de actividades vinculados a ellos quedarían huérfanos o romperían el sistema. Con el borrado lógico, el historial permanece intacto para auditorías y estadísticas.

### 3. Estandarización y Restricciones de Integridad
* **Seguridad de Credenciales:** El campo de contraseñas de los usuarios está dimensionado a `VARCHAR(255)` para admitir cadenas complejas resultantes de algoritmos de encriptación por Hash (como BCrypt o PBKDF2), garantizando que las contraseñas nunca se almacenen en texto plano.
* **Control de Duplicados:** La columna de correos electrónicos en la tabla de usuarios posee una restricción `UNIQUE`, evitando fallos de calidad por suplantación de identidad o cuentas duplicadas.
* **Estandarización de Fechas:** Las fechas de creación de los semilleros y registros se capturan directamente en el servidor usando `CAST(GETDATE() AS DATE)`, omitiendo las horas, minutos y segundos. Esto asegura que cuando el Investigador realice búsquedas por fecha, las consultas sean 100% precisas y consistentes.
