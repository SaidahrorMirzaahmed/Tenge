﻿using Tenge.Domain.Commons;

namespace Tenge.Domain.Entities;

public class Item : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CollectionId {  get; set; }
    public Collection Collection { get; set; }
    public long? PictureId { get; set; }
    public Asset? Picture { get; set; }
    public string? CustomString1Value { get; set; }
    public string? CustomString2Value { get; set; }
    public string? CustomString3Value { get; set; }
    public int? CustomInt1Value { get; set; }
    public int? CustomInt2Value { get; set; }
    public int? CustomInt3Value { get; set; }
    public DateTime? CustomDate1Value { get; set; }
    public DateTime? CustomDate2Value { get; set; }
    public DateTime? CustomDate3Value { get; set; }
}
