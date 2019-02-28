--Seleciona Todos os Usuarios
SELECT * FROM USUARIOS

--Seleciona Todos os Estudios
SELECT * FROM ESTUDIOS

--Seleciona Todos os Jogos
SELECT * FROM JOGOS

--Seleciona Todos os Jogos e seus Estudios
SELECT * FROM 
JOGOS JOIN ESTUDIOS
ON
JOGOS.EstudioId = ESTUDIOS.EstudioId

--Seleciona Todos os Estudios, até os que não fazem nenhuma refencia a um jogo
SELECT * FROM
ESTUDIOS ES Left JOIN JOGOS JG
ON
ES.EstudioId = JG.EstudioId

--Seleciona o usuario com email e senha específico
SELECT * FROM	USUARIOS WHERE Email = 'cliente@cliente.com' and Senha = 'cliente'

SELECT * FROM	USUARIOS WHERE Email = 'admin@admin.com' and Senha = 'admin'


--Seleciona o jogo pelo id específico
SELECT * FROM JOGOS WHERE JogoId = 3

SELECT * FROM JOGOS WHERE JogoId = 4


--Seleciona o estudio pelo id específico
SELECT * FROM ESTUDIOS WHERE EstudioId = 1

SELECT * FROM ESTUDIOS WHERE EstudioId = 2

SELECT * FROM ESTUDIOS WHERE EstudioId = 3