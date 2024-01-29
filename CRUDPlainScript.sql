--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1
-- Dumped by pg_dump version 16.1

-- Started on 2024-01-30 00:24:10

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 16404)
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    "Id" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16409)
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "RoleId" integer NOT NULL
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- TOC entry 4841 (class 0 OID 16404)
-- Dependencies: 215
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Role" ("Id", "Name") VALUES (1, 'User');
INSERT INTO public."Role" ("Id", "Name") VALUES (2, 'Role');


--
-- TOC entry 4842 (class 0 OID 16409)
-- Dependencies: 216
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4692 (class 2606 OID 16408)
-- Name: Role Role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4694 (class 2606 OID 16413)
-- Name: User User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4695 (class 1259 OID 16425)
-- Name: fki_E; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_E" ON public."User" USING btree ("RoleId");


--
-- TOC entry 4696 (class 1259 OID 16419)
-- Name: fki_Role_fkey; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Role_fkey" ON public."User" USING btree ("RoleId");


--
-- TOC entry 4697 (class 2606 OID 16420)
-- Name: User Role_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "Role_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("Id") NOT VALID;


-- Completed on 2024-01-30 00:24:10

--
-- PostgreSQL database dump complete
--

