SET search_path TO fias;
--Очистка от неактивных и неактуальных объектов
DELETE FROM as_addr_obj WHERE isactive = 0 OR isactual = 0 or id IS NULL;
DELETE FROM as_addr_obj_division WHERE id IS NULL;
DELETE FROM as_addr_obj_types WHERE id IS NULL;
DELETE FROM as_adm_hierarchy WHERE isactive = 0 OR id IS NULL;
DELETE FROM as_apartment_types WHERE id IS NULL;
DELETE FROM as_apartments WHERE isactive = 0 OR isactual = 0 OR id IS NULL;
DELETE FROM as_carplaces WHERE isactive = 0 OR isactual = 0 OR id IS NULL;
DELETE FROM as_change_history WHERE changeid IS NULL;
DELETE FROM as_house_types WHERE id IS NULL;
DELETE FROM as_houses WHERE isactive = 0 OR isactual = 0 OR id IS NULL;
DELETE FROM as_mun_hierarchy WHERE isactive = 0 OR id IS NULL;
DELETE FROM as_normative_docs WHERE id IS NULL;
DELETE FROM as_normative_docs_kinds WHERE id IS NULL;
DELETE FROM as_normative_docs_types WHERE id IS NULL;
DELETE FROM as_object_levels WHERE level IS NULL;
DELETE FROM as_operation_types WHERE id IS NULL;
DELETE FROM as_param WHERE id IS NULL;
DELETE FROM as_param_types WHERE id IS NULL;
DELETE FROM as_reestr_objects WHERE isactive = 0 OR objectid IS NULL;
DELETE FROM as_room_types WHERE id IS NULL;
DELETE FROM as_rooms WHERE isactive = 0 OR isactual = 0 OR id IS NULL;
DELETE FROM as_steads WHERE isactive = 0 OR isactual = 0 OR id IS NULL;

--фикс типов колонок
--as_addr_obj
ALTER TABLE as_addr_obj
    ALTER COLUMN level TYPE smallint
	USING level::smallint;

--as_adm_hierarchy
ALTER TABLE as_adm_hierarchy
    ALTER COLUMN regioncode TYPE smallint
	USING regioncode::smallint;

--as_steads
ALTER TABLE as_steads
    ALTER COLUMN opertypeid TYPE smallint
	USING opertypeid::smallint;

















CREATE INDEX as_addr_obj_level_index
    ON fias.as_addr_obj USING btree
    (level ASC NULLS LAST)
    TABLESPACE pg_default;
CREATE INDEX as_addr_obj_name_idx
    ON fias.as_addr_obj USING gist
    (name COLLATE pg_catalog."default" gist_trgm_ops)
    TABLESPACE pg_default;
CREATE INDEX as_addr_obj_objectid_idx
    ON fias.as_addr_obj USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;	
CREATE INDEX as_addr_obj_name_idx
    ON fias.as_addr_obj USING gist
    (name gist_trgm_ops);
ALTER TABLE fias.as_addr_obj
    ADD CONSTRAINT as_addr_obj_pkey PRIMARY KEY (id);
	
	
--as_addr_obj_division_pkey
ALTER TABLE fias.as_addr_obj_division
    ADD CONSTRAINT as_addr_obj_division_pkey PRIMARY KEY (id);
	
--as_addr_obj_types_pkey
ALTER TABLE fias.as_addr_obj_types
    ADD CONSTRAINT as_addr_obj_types_pkey PRIMARY KEY (id);
	
--as_adm_hierarchy_idx, pkey
CREATE INDEX as_adm_hierarchy_objectid_idx
    ON fias.as_adm_hierarchy USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;
CREATE INDEX as_adm_hierarchy_parentobjid_idx
    ON fias.as_adm_hierarchy USING btree
    (parentobjid ASC NULLS LAST)
    TABLESPACE pg_default;
ALTER TABLE fias.as_adm_hierarchy
    ADD CONSTRAINT as_adm_hierarchy_pkey PRIMARY KEY (id);
	
--as_apartment_types_pkey
ALTER TABLE fias.as_apartment_types
    ADD CONSTRAINT as_apartment_types_pkey PRIMARY KEY (id);	

--as_apartments_idx, pkey
CREATE INDEX as_apartments_objectid_idx
    ON fias.as_apartments USING btree
    (objectid ASC NULLS LAST);
ALTER TABLE fias.as_apartments
    ADD CONSTRAINT as_apartments_pkey PRIMARY KEY (id);		
	
--as_carplaces_idx, pkey
CREATE INDEX as_carplaces_objectid_idx
    ON fias.as_carplaces USING btree
    (objectid ASC NULLS LAST);
ALTER TABLE fias.as_carplaces
    ADD CONSTRAINT as_carplaces_pkey PRIMARY KEY (id);		
	
--as_house_types_pkey
ALTER TABLE fias.as_house_types
    ADD CONSTRAINT as_house_types_pkey PRIMARY KEY (id);	
	
	
--as_houses_idx, pkey
CREATE INDEX as_houses_objectid_idx
    ON fias.as_houses USING btree
    (objectid ASC NULLS LAST);
ALTER TABLE fias.as_houses
    ADD CONSTRAINT as_houses_pkey PRIMARY KEY (id);		
	
--as_mun_hierarchy_idx, pkey
CREATE INDEX as_mun_hiererchy_objectid_idx
    ON fias.as_mun_hierarchy USING btree
    (objectid ASC NULLS LAST);
CREATE INDEX as_mun_hiererchy_parentobjid_idx
    ON fias.as_mun_hierarchy USING btree
    (parentobjid ASC NULLS LAST)
    TABLESPACE pg_default;	
ALTER TABLE fias.as_mun_hierarchy
    ADD CONSTRAINT as_mun_hierarchy_pkey PRIMARY KEY (id);	
	
--as_object_levels
ALTER TABLE fias.as_object_levels
    ADD CONSTRAINT as_object_levels_pkey PRIMARY KEY (level);		
	
--as_param_idx, pkey
CREATE INDEX as_param_objectid_idx
    ON fias.as_param USING btree
    (objectid ASC NULLS LAST);
ALTER TABLE fias.as_param
    ADD CONSTRAINT as_param_pkey PRIMARY KEY (id);		
	
--as_param_types
ALTER TABLE fias.as_param_types
    ADD CONSTRAINT as_param_types_pkey PRIMARY KEY (id);			
CREATE INDEX as_param_typeid_idx
    ON fias.as_param USING btree
    (typeid ASC NULLS LAST)
    TABLESPACE pg_default;
	
--as_reestr_objects_idx, pkey
CREATE INDEX as_reestr_objects_idx
    ON fias.as_reestr_objects USING btree
    (objectid ASC NULLS LAST);
ALTER TABLE fias.as_reestr_objects
    ADD CONSTRAINT as_reestr_objects_pkey PRIMARY KEY (objectid);	
	
--as_room_types_pkey
ALTER TABLE fias.as_room_types
    ADD CONSTRAINT as_room_types_pkey PRIMARY KEY (id);	
	
--as_rooms_idx, pkey
CREATE INDEX as_rooms_objectid_idx
    ON fias.as_rooms USING btree
    (objectid ASC NULLS LAST);
ALTER TABLE fias.as_rooms
    ADD CONSTRAINT as_rooms_pkey PRIMARY KEY (id);	

--as_steads_idx, pkey
CREATE INDEX as_steads_objectid_idx
    ON fias.as_steads USING btree
    (objectid ASC NULLS LAST);
ALTER TABLE fias.as_steads
    ADD CONSTRAINT as_steads_pkey PRIMARY KEY (id);	
SET search_path TO public;