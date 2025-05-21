CREATE DATABASE GNUcannabis;
USE GNUcannabis;

-- ========================================
-- 1. Tipos de documento
-- ========================================
CREATE TABLE TiposDocumento (
    IdTipoDocumento INT PRIMARY KEY IDENTITY(1,1),
    NombreTipo NVARCHAR(30) NOT NULL UNIQUE
);

-- Datos iniciales
INSERT INTO TiposDocumento (NombreTipo) VALUES
('DNI'), ('Pasaporte'), ('Cédula de Extranjería'), ('RUT');

-- ========================================
-- 2. Personas
-- ========================================
CREATE TABLE Personas (
    IdPersona INT PRIMARY KEY IDENTITY(1,1),
    NombreCompleto NVARCHAR(100) NOT NULL,
    IdTipoDocumento INT NOT NULL,
    NumeroDocumento NVARCHAR(30) NOT NULL UNIQUE,
    FOREIGN KEY (IdTipoDocumento) REFERENCES TiposDocumento(IdTipoDocumento)
);

-- ========================================
-- 3. Roles
-- ========================================
CREATE TABLE Roles (
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(20) NOT NULL UNIQUE
);
-- ========================================
-- 5. Tipos de Cultivo
-- ========================================
CREATE TABLE TiposCultivo (
    IdTipoCultivo INT PRIMARY KEY IDENTITY(1,1),
    NombreTipo NVARCHAR(30) NOT NULL UNIQUE
);

-- ========================================
-- 6. Cultivos
-- ========================================
CREATE TABLE Cultivos (
    IdCultivo INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    IdTipoCultivo INT NOT NULL,
    FOREIGN KEY (IdTipoCultivo) REFERENCES TiposCultivo(IdTipoCultivo)
);



-- ========================================
-- 4. Usuarios
-- ========================================
CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    IdPersona INT NOT NULL,
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    ContrasenaHash NVARCHAR(200) NOT NULL,
    IdRol INT NOT NULL,
    Estado BIT NOT NULL,
    IdCultivo INT NULL,  -- FK para asignar el cultivo al que pertenece el usuario
    FOREIGN KEY (IdPersona) REFERENCES Personas(IdPersona),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol),
    FOREIGN KEY (IdCultivo) REFERENCES Cultivos(IdCultivo) ON DELETE SET NULL
);

-- ========================================
-- 7. Tipos de Planta
-- ========================================
CREATE TABLE TiposPlanta (
    IdTipoPlanta INT PRIMARY KEY IDENTITY(1,1),
    NombreTipo NVARCHAR(30) NOT NULL UNIQUE
);

-- ========================================
-- 8. Estados de Planta
-- ========================================
CREATE TABLE EstadosPlanta (
    IdEstadoPlanta INT PRIMARY KEY IDENTITY(1,1),
    NombreEstado NVARCHAR(30) NOT NULL UNIQUE
);

-- ========================================
-- 9. Plantas
-- ========================================
CREATE TABLE Plantas (
    IdPlanta INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    IdCultivo INT NOT NULL,
    IdTipoPlanta INT NOT NULL,
    IdEstadoPlanta INT NOT NULL,
    FOREIGN KEY (IdCultivo) REFERENCES Cultivos(IdCultivo),
    FOREIGN KEY (IdTipoPlanta) REFERENCES TiposPlanta(IdTipoPlanta),
    FOREIGN KEY (IdEstadoPlanta) REFERENCES EstadosPlanta(IdEstadoPlanta)
);

-- ========================================
-- 10. Historial de la Planta
-- ========================================
CREATE TABLE HistorialPlanta (
    IdHistorial INT PRIMARY KEY IDENTITY(1,1),
    IdPlanta INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Descripcion NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (IdPlanta) REFERENCES Plantas(IdPlanta)
);

-- ==================
-- Datos
-- ==================

INSERT INTO TiposDocumento (NombreTipo) VALUES 
('DNI'), 
('Pasaporte'), 
('Cédula de Extranjería'), 
('RUT');

SELECT * FROM Personas;


INSERT INTO Personas (NombreCompleto, IdTipoDocumento, NumeroDocumento) VALUES 
('Carlos Pérez', 1, '12345678'),
('Ana Torres', 3, 'CE987654'),
('Lucía González', 2, 'P1234567');


INSERT INTO Roles (NombreRol) VALUES 
('Administrador'), 
('Jardinero');


INSERT INTO Usuarios (IdPersona, Correo, ContrasenaHash, IdRol, Estado) VALUES 
(1, 'carlos@admin.com', 'hashed_admin_pass', 1, 1),
(2, 'ana@jardin.com', 'hashed_ana_pass', 2, 1),
(3, 'lucia@jardin.com', 'hashed_lucia_pass', 2, 0);  -- Inactivo





INSERT INTO TiposCultivo (NombreTipo) VALUES 
('Interior'), 
('Exterior');


INSERT INTO Cultivos (Nombre, IdTipoCultivo) VALUES 
('Cultivo Norte', 1),  -- Ana
('Cultivo Sur', 2);    -- Lucía (aunque esté inactiva, puede haber historial)


INSERT INTO TiposPlanta (NombreTipo) VALUES 
('Sativa'), 
('Índica'), 
('Híbrida');


INSERT INTO EstadosPlanta (NombreEstado) VALUES 
('Germinación'), 
('Crecimiento'), 
('Floración'), 
('Muerta');

INSERT INTO Plantas (Nombre, IdCultivo, IdTipoPlanta, IdEstadoPlanta) VALUES 
('Planta 1', 1, 1, 1),
('Planta 2', 1, 2, 2),
('Planta 3', 2, 3, 3);


INSERT INTO HistorialPlanta (IdPlanta, Fecha, Descripcion) VALUES 
(1, GETDATE(), 'Inicio de germinación.'),
(1, GETDATE(), 'Detectada humedad excesiva.'),
(2, GETDATE(), 'Aplicación de fertilizante.'),
(3, GETDATE(), 'Comenzó la floración.'),
(3, GETDATE(), 'Detectada plaga, se aplicó tratamiento.');




-- Mostrar todos los datos de TiposDocumento
SELECT * FROM TiposDocumento;

-- Mostrar todos los datos de Personas
SELECT * FROM Personas;

-- Mostrar todos los datos de Roles
SELECT * FROM Roles;

-- Mostrar todos los datos de Usuarios
SELECT * FROM Usuarios;

-- Mostrar todos los datos de TiposCultivo
SELECT * FROM TiposCultivo;

-- Mostrar todos los datos de Cultivos
SELECT * FROM Cultivos;

-- Mostrar todos los datos de TiposPlanta
SELECT * FROM TiposPlanta;

-- Mostrar todos los datos de EstadosPlanta
SELECT * FROM EstadosPlanta;

-- Mostrar todos los datos de Plantas
SELECT * FROM Plantas;

-- Mostrar todos los datos de HistorialPlanta
SELECT * FROM HistorialPlanta;



ALTER TABLE Plantas
DROP CONSTRAINT FK__Plantas__IdCulti__52593CB8;

ALTER TABLE Plantas
ADD CONSTRAINT FK__Plantas__IdCulti__52593CB8
FOREIGN KEY (IdCultivo) REFERENCES Cultivos(IdCultivo)
ON DELETE CASCADE;
----------------------------------------------------
ALTER TABLE HistorialPlanta
DROP CONSTRAINT FK__Historial__IdPla__5812160E;

ALTER TABLE HistorialPlanta
ADD CONSTRAINT FK__Historial__IdPla__5812160E
FOREIGN KEY (IdPlanta) REFERENCES Plantas(IdPlanta)
ON DELETE CASCADE;

-------------------------------------------------------------------------
