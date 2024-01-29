PGDMP                        |            CRUD    16.1    16.1     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16398    CRUD    DATABASE     z   CREATE DATABASE "CRUD" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "CRUD";
                postgres    false            �            1259    16404    Role    TABLE     e   CREATE TABLE public."Role" (
    "Id" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
    DROP TABLE public."Role";
       public         heap    postgres    false            �            1259    16409    User    TABLE     �   CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "RoleId" integer NOT NULL
);
    DROP TABLE public."User";
       public         heap    postgres    false            �          0    16404    Role 
   TABLE DATA           .   COPY public."Role" ("Id", "Name") FROM stdin;
    public          postgres    false    215   I       �          0    16409    User 
   TABLE DATA           8   COPY public."User" ("Id", "Name", "RoleId") FROM stdin;
    public          postgres    false    216   t       T           2606    16408    Role Role_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Role" DROP CONSTRAINT "Role_pkey";
       public            postgres    false    215            V           2606    16413    User User_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    216            W           1259    16425    fki_E    INDEX     >   CREATE INDEX "fki_E" ON public."User" USING btree ("RoleId");
    DROP INDEX public."fki_E";
       public            postgres    false    216            X           1259    16419    fki_Role_fkey    INDEX     F   CREATE INDEX "fki_Role_fkey" ON public."User" USING btree ("RoleId");
 #   DROP INDEX public."fki_Role_fkey";
       public            postgres    false    216            Y           2606    16420    User Role_fkey    FK CONSTRAINT        ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "Role_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("Id") NOT VALID;
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "Role_fkey";
       public          postgres    false    216    4692    215            �      x�3�-N-�2���I����� 0�c      �      x������ � �     