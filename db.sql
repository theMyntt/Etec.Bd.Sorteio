USE master;
GO

DROP DATABASE IF EXISTS sorteio_db;
GO

CREATE DATABASE sorteio_db;
GO

USE sorteio_db;
GO

CREATE TABLE participantes ( 
    id_participante INTEGER IDENTITY(1,1) PRIMARY KEY, 
    nome NVARCHAR(100) NOT NULL 
);
GO

CREATE TABLE sorteios ( 
    id_sorteio INTEGER IDENTITY(1,1) PRIMARY KEY, 
    id_participante INTEGER NOT NULL, 
    id_amigo_secreto INTEGER NOT NULL, 
    FOREIGN KEY (id_participante) REFERENCES participantes(id_participante), 
    FOREIGN KEY (id_amigo_secreto) REFERENCES participantes(id_participante) 
);
GO

CREATE TABLE presentes ( 
    id_presente INTEGER IDENTITY(1,1) PRIMARY KEY, 
    id_sorteio INTEGER, 
    descricao NVARCHAR(255) NOT NULL, 
    FOREIGN KEY (id_sorteio) REFERENCES sorteios(id_sorteio) 
);
GO

CREATE TABLE mensagens ( 
    id_mensagem INTEGER IDENTITY(1,1) PRIMARY KEY, 
    id_remetente INTEGER NOT NULL, 
    id_destinatario INTEGER NOT NULL, 
    mensagem NVARCHAR(MAX), 
    FOREIGN KEY (id_remetente) REFERENCES participantes(id_participante), 
    FOREIGN KEY (id_destinatario) REFERENCES participantes(id_participante) 
);
GO

INSERT INTO participantes VALUES('GABRIEL ARAÚJO');
GO

INSERT INTO participantes VALUES('GABRIEL PEDRO');
GO

INSERT INTO participantes VALUES('YASMIM KONDO');
GO

INSERT INTO participantes VALUES('RAYSSA VICTORIA');
GO

INSERT INTO presentes VALUES (NULL, 'PRESENTE 1');
GO

INSERT INTO presentes VALUES (NULL, 'PRESENTE 2');
GO

INSERT INTO presentes VALUES (NULL, 'PRESENTE 3');
GO

INSERT INTO presentes VALUES (NULL, 'PRESENTE 4');
GO

CREATE PROCEDURE realizar_sorteio
AS
BEGIN
    DECLARE @id_participante INT;
    DECLARE @v_count INT = 0;
    DECLARE @v_temp INT;
    
    DECLARE @v_participantes TABLE (id_participante INT, row_num INT);
    DECLARE @v_amigos TABLE (id_participante INT, amigo_secreto INT);

    DECLARE c_participantes CURSOR FOR
        SELECT id_participante
        FROM participantes;
		
    OPEN c_participantes;

    FETCH NEXT FROM c_participantes INTO @id_participante;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @v_count = @v_count + 1;
        INSERT INTO @v_participantes (id_participante, row_num)
        VALUES (@id_participante, @v_count);

        FETCH NEXT FROM c_participantes INTO @id_participante;
    END;

    IF @v_count < 2
    BEGIN
        RAISERROR('É necessário pelo menos 2 participantes para realizar o sorteio.', 16, 1);
        CLOSE c_participantes;
        DEALLOCATE c_participantes;
        RETURN;
    END;

    DECLARE @i INT = 1;
    WHILE @i <= @v_count
    BEGIN
        WHILE 1 = 1
        BEGIN
            SET @v_temp = CAST(1 + (RAND() * @v_count) AS INT);

            IF (SELECT COUNT(*) FROM @v_amigos WHERE amigo_secreto = @v_temp) = 0
               AND (SELECT id_participante FROM @v_participantes WHERE row_num = @i) != @v_temp
            BEGIN
                INSERT INTO @v_amigos (id_participante, amigo_secreto)
                VALUES ((SELECT id_participante FROM @v_participantes WHERE row_num = @i), @v_temp);
				
                BREAK;
            END
        END

        SET @i = @i + 1;
    END;

    INSERT INTO sorteios (id_participante, id_amigo_secreto)
    SELECT id_participante, amigo_secreto
    FROM @v_amigos;

    PRINT 'Sorteio realizado com sucesso!';

    CLOSE c_participantes;
    DEALLOCATE c_participantes;

END;
GO

-- EXEC realizar_sorteio;
-- GO
