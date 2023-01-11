SET search_path TO fias;
CREATE EXTENSION pg_trgm;
--as_addr_obj_id

-- DROP INDEX IF EXISTS fias.as_addr_obj_id_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_id_idx
    ON fias.as_addr_obj USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_addr_obj_isactive_idx

-- DROP INDEX IF EXISTS fias.as_addr_obj_isactive_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_isactive_idx
    ON fias.as_addr_obj USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_addr_obj_isactual_idx

-- DROP INDEX IF EXISTS fias.as_addr_obj_isactual_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_isactual_idx
    ON fias.as_addr_obj USING btree
    (isactual ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_addr_obj_level_idx

-- DROP INDEX IF EXISTS fias.as_addr_obj_level_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_level_idx
    ON fias.as_addr_obj USING btree
    (level ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_addr_obj_objectguid_idx

-- DROP INDEX IF EXISTS fias.as_addr_obj_objectguid_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_objectguid_idx
    ON fias.as_addr_obj USING btree
    (objectguid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_addr_obj_objectid_idx

-- DROP INDEX IF EXISTS fias.as_addr_obj_objectid_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_objectid_idx
    ON fias.as_addr_obj USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;


-- Index: as_addr_obj_types_id_idx

-- DROP INDEX IF EXISTS fias.as_addr_obj_types_id_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_types_id_idx
    ON fias.as_addr_obj_types USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;

-- Index: as_addr_obj_name_idx

-- DROP INDEX IF EXISTS fias.as_addr_obj_name_idx;

CREATE INDEX IF NOT EXISTS as_addr_obj_name_idx
    ON as_addr_obj USING gin
    (name COLLATE pg_catalog."default" gin_trgm_ops)
    TABLESPACE pg_default;







-- Index: as_adm_hierarchy_id_idx

-- DROP INDEX IF EXISTS fias.as_adm_hierarchy_id_idx;

CREATE INDEX IF NOT EXISTS as_adm_hierarchy_id_idx
    ON fias.as_adm_hierarchy USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_adm_hierarchy_isactive_idx

-- DROP INDEX IF EXISTS fias.as_adm_hierarchy_isactive_idx;

CREATE INDEX IF NOT EXISTS as_adm_hierarchy_isactive_idx
    ON fias.as_adm_hierarchy USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_adm_hierarchy_objectid_idx

-- DROP INDEX IF EXISTS fias.as_adm_hierarchy_objectid_idx;

CREATE INDEX IF NOT EXISTS as_adm_hierarchy_objectid_idx
    ON fias.as_adm_hierarchy USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_adm_hierarchy_parentobjid_idx

-- DROP INDEX IF EXISTS fias.as_adm_hierarchy_parentobjid_idx;

CREATE INDEX IF NOT EXISTS as_adm_hierarchy_parentobjid_idx
    ON fias.as_adm_hierarchy USING btree
    (parentobjid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_adm_hierarchy_region_idx

-- DROP INDEX IF EXISTS fias.as_adm_hierarchy_region_idx;

CREATE INDEX IF NOT EXISTS as_adm_hierarchy_region_idx
    ON fias.as_adm_hierarchy USING btree
    (regioncode ASC NULLS LAST)
    TABLESPACE pg_default;









-- Index: as_apartments_id_idx

-- DROP INDEX IF EXISTS fias.as_apartments_id_idx;

CREATE INDEX IF NOT EXISTS as_apartments_id_idx
    ON fias.as_apartments USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_apartments_isactive_idx

-- DROP INDEX IF EXISTS fias.as_apartments_isactive_idx;

CREATE INDEX IF NOT EXISTS as_apartments_isactive_idx
    ON fias.as_apartments USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_apartments_isactual_idx

-- DROP INDEX IF EXISTS fias.as_apartments_isactual_idx;

CREATE INDEX IF NOT EXISTS as_apartments_isactual_idx
    ON fias.as_apartments USING btree
    (isactual ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_apartments_objectguid_idx

-- DROP INDEX IF EXISTS fias.as_apartments_objectguid_idx;

CREATE INDEX IF NOT EXISTS as_apartments_objectguid_idx
    ON fias.as_apartments USING btree
    (objectguid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_apartments_objectid_idx

-- DROP INDEX IF EXISTS fias.as_apartments_objectid_idx;

CREATE INDEX IF NOT EXISTS as_apartments_objectid_idx
    ON fias.as_apartments USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;








-- Index: as_carplaces_id_idx

-- DROP INDEX IF EXISTS fias.as_carplaces_id_idx;

CREATE INDEX IF NOT EXISTS as_carplaces_id_idx
    ON fias.as_carplaces USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_carplaces_isactive_idx

-- DROP INDEX IF EXISTS fias.as_carplaces_isactive_idx;

CREATE INDEX IF NOT EXISTS as_carplaces_isactive_idx
    ON fias.as_carplaces USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_carplaces_isactual_idx

-- DROP INDEX IF EXISTS fias.as_carplaces_isactual_idx;

CREATE INDEX IF NOT EXISTS as_carplaces_isactual_idx
    ON fias.as_carplaces USING btree
    (isactual ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_carplaces_objectguid_idx

-- DROP INDEX IF EXISTS fias.as_carplaces_objectguid_idx;

CREATE INDEX IF NOT EXISTS as_carplaces_objectguid_idx
    ON fias.as_carplaces USING btree
    (objectguid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_carplaces_objectid_idx

-- DROP INDEX IF EXISTS fias.as_carplaces_objectid_idx;

CREATE INDEX IF NOT EXISTS as_carplaces_objectid_idx
    ON fias.as_carplaces USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;






-- Index: as_houses_id_idx

-- DROP INDEX IF EXISTS fias.as_houses_id_idx;

CREATE INDEX IF NOT EXISTS as_houses_id_idx
    ON fias.as_houses USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_houses_isactive_idx

-- DROP INDEX IF EXISTS fias.as_houses_isactive_idx;

CREATE INDEX IF NOT EXISTS as_houses_isactive_idx
    ON fias.as_houses USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_houses_isactual_idx

-- DROP INDEX IF EXISTS fias.as_houses_isactual_idx;

CREATE INDEX IF NOT EXISTS as_houses_isactual_idx
    ON fias.as_houses USING btree
    (isactual ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_houses_objectguid_idx

-- DROP INDEX IF EXISTS fias.as_houses_objectguid_idx;

CREATE INDEX IF NOT EXISTS as_houses_objectguid_idx
    ON fias.as_houses USING btree
    (objectguid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_houses_objectid_idx

-- DROP INDEX IF EXISTS fias.as_houses_objectid_idx;

CREATE INDEX IF NOT EXISTS as_houses_objectid_idx
    ON fias.as_houses USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;










-- Index: as_steads_id_idx

-- DROP INDEX IF EXISTS fias.as_steads_id_idx;

CREATE INDEX IF NOT EXISTS as_steads_id_idx
    ON fias.as_steads USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_steads_isactive_idx

-- DROP INDEX IF EXISTS fias.as_steads_isactive_idx;

CREATE INDEX IF NOT EXISTS as_steads_isactive_idx
    ON fias.as_steads USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_steads_isactual_idx

-- DROP INDEX IF EXISTS fias.as_steads_isactual_idx;

CREATE INDEX IF NOT EXISTS as_steads_isactual_idx
    ON fias.as_steads USING btree
    (isactual ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_steads_objectguid_idx

-- DROP INDEX IF EXISTS fias.as_steads_objectguid_idx;

CREATE INDEX IF NOT EXISTS as_steads_objectguid_idx
    ON fias.as_steads USING btree
    (objectguid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_steads_objectid_idx

-- DROP INDEX IF EXISTS fias.as_steads_objectid_idx;

CREATE INDEX IF NOT EXISTS as_steads_objectid_idx
    ON fias.as_steads USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;











-- Index: as_rooms_id_idx

-- DROP INDEX IF EXISTS fias.as_rooms_id_idx;

CREATE INDEX IF NOT EXISTS as_rooms_id_idx
    ON fias.as_rooms USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_rooms_isactive_idx

-- DROP INDEX IF EXISTS fias.as_rooms_isactive_idx;

CREATE INDEX IF NOT EXISTS as_rooms_isactive_idx
    ON fias.as_rooms USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_rooms_isactual_idx

-- DROP INDEX IF EXISTS fias.as_rooms_isactual_idx;

CREATE INDEX IF NOT EXISTS as_rooms_isactual_idx
    ON fias.as_rooms USING btree
    (isactual ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_rooms_objectguid_idx

-- DROP INDEX IF EXISTS fias.as_rooms_objectguid_idx;

CREATE INDEX IF NOT EXISTS as_rooms_objectguid_idx
    ON fias.as_rooms USING btree
    (objectguid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_rooms_objectid_idx

-- DROP INDEX IF EXISTS fias.as_rooms_objectid_idx;

CREATE INDEX IF NOT EXISTS as_rooms_objectid_idx
    ON fias.as_rooms USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;






-- Index: as_reestr_objects_isactive_idx

-- DROP INDEX IF EXISTS fias.as_reestr_objects_isactive_idx;

CREATE INDEX IF NOT EXISTS as_reestr_objects_isactive_idx
    ON fias.as_reestr_objects USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;

-- Index: as_reestr_objects_objectguid_idx

-- DROP INDEX IF EXISTS fias.as_reestr_objects_objectguid_idx;

CREATE INDEX IF NOT EXISTS as_reestr_objects_objectguid_idx
    ON fias.as_reestr_objects USING btree
    (objectguid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_reestr_objects_objectid_idx

-- DROP INDEX IF EXISTS fias.as_reestr_objects_objectid_idx;

CREATE INDEX IF NOT EXISTS as_reestr_objects_objectid_idx
    ON fias.as_reestr_objects USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;










-- Index: as_mun_hierarchy_id_idx

-- DROP INDEX IF EXISTS fias.as_mun_hierarchy_id_idx;

CREATE INDEX IF NOT EXISTS as_mun_hierarchy_id_idx
    ON fias.as_mun_hierarchy USING btree
    (id ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_mun_hierarchy_isactive_idx

-- DROP INDEX IF EXISTS fias.as_mun_hierarchy_isactive_idx;

CREATE INDEX IF NOT EXISTS as_mun_hierarchy_isactive_idx
    ON fias.as_mun_hierarchy USING btree
    (isactive ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_mun_hierarchy_objectid_idx

-- DROP INDEX IF EXISTS fias.as_mun_hierarchy_objectid_idx;

CREATE INDEX IF NOT EXISTS as_mun_hierarchy_objectid_idx
    ON fias.as_mun_hierarchy USING btree
    (objectid ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: as_mun_hierarchy_parentobjid_idx

-- DROP INDEX IF EXISTS fias.as_mun_hierarchy_parentobjid_idx;

CREATE INDEX IF NOT EXISTS as_mun_hierarchy_parentobjid_idx
    ON fias.as_mun_hierarchy USING btree
    (parentobjid ASC NULLS LAST)
    TABLESPACE pg_default;

-- Index: as_param_value_idx

-- DROP INDEX IF EXISTS fias.as_param_value_idx;

CREATE INDEX IF NOT EXISTS as_param_value_idx
    ON fias.as_param USING gin
    (value COLLATE pg_catalog."default" gin_trgm_ops)
    TABLESPACE pg_default;
SET search_path TO public;